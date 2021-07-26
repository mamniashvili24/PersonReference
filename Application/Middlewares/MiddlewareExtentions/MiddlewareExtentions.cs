using Microsoft.AspNetCore.Builder;
using Application.Middlewares.Middlewares;

namespace Application.Middlewares.MiddlewareExtentions
{
    public static class MiddlewareExtentions
    {
        public static void AddExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
        public static void AddLanguageMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<LanguageMiddleware>();
        }
    }
}