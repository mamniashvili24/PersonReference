using System;
using Serilog;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Infrastructure.CommonTypes.Implementations;

namespace Application.Middlewares.Middlewares
{
    public class ExceptionMiddleware
    {
        #region [ Constructor(s) ]

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region [ Public Method(s) ]

        public async Task InvokeAsync(HttpContext httpContext, ILogger logger)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        #endregion

        #region [ Private Method(s) ]

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new DataResponse()
            {
                Message = ex.Message,
                IsError = true
            }));
        }
        
        #endregion
        
        #region [ Private Field(s) ]

        private readonly RequestDelegate _next;

        #endregion
    }
}