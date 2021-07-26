using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Infrastructure.CommonTypes.Implementations;
using Infrastructure.Database.UnitOfWork.Abstractions;

namespace Application.Middlewares.Middlewares
{
    public class LanguageMiddleware
    {
        #region [ Constructor(s) ]

        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task InvokeAsync(HttpContext httpContext, IUnitOfWork unitOfWork)
        {
            var originBody = httpContext.Response.Body;

            var responseBody = await ReadBodyAsync(httpContext);

            if (!string.IsNullOrEmpty(responseBody))
            {
                responseBody = await TranslateResponseAsync(httpContext, unitOfWork, responseBody);
            }
            await WriteBodyAsync(originBody, responseBody);
        }

        #endregion

        #region [ Private Method(s) ]

        private async Task<string> TranslateResponseAsync(HttpContext httpContext, IUnitOfWork unitOfWork, string responseBody)
        {
            var languageCode = httpContext.Request.Headers["Accept-Language"].ToString();
            var language = await unitOfWork.LanguageRepository.FirstOrDefaultAsync(l => l.LanguageCode.ToLower() == languageCode.ToLower());
            if (language == null)
            {
                language = await unitOfWork.LanguageRepository.FirstOrDefaultAsync(l => l.IsDefault);
            }

            if (language == null)
            {
                return responseBody;
            }

            var deserializedData = JsonConvert.DeserializeObject<DataResponse>(responseBody);
            if (deserializedData.IsError)
            {
                var translation = await unitOfWork.TranslationRepository.FirstOrDefaultAsync(t => t.Key.ToLower() == deserializedData.Message.ToLower());
                if (translation == null)
                {
                    return responseBody;
                }

                if (!string.IsNullOrEmpty(translation.Value))
                {
                    deserializedData.Message = translation.Value;
                }
                responseBody = JsonConvert.SerializeObject(deserializedData);
            }
            return responseBody;
        }
        private async Task WriteBodyAsync(Stream originBody, string responseBody)
        {
            var memoryStreamModified = new MemoryStream();
            var sw = new StreamWriter(memoryStreamModified);
            sw.Write(responseBody);
            sw.Flush();
            memoryStreamModified.Position = 0;

            await memoryStreamModified.CopyToAsync(originBody);
        }
        private async Task<string> ReadBodyAsync(HttpContext httpContext)
        {
            var memStream = new MemoryStream();
            httpContext.Response.Body = memStream;

            await _next(httpContext);

            memStream.Position = 0;
            var responseBody = new StreamReader(memStream).ReadToEnd();
            return responseBody;
        }

        #endregion

        #region [ Private Field(s) ]
        
        private readonly RequestDelegate _next;

        #endregion
    }
}