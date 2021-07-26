using System.Reflection;
using Infrastructure.Extentions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class Extentions
    {
        public static void AddInfrastructure(this IServiceCollection services
        , IConfiguration configuration
        , string sqlConectionSectionName = "DefaultConnection"
        , string redisConectionSectionName = "Redis")
        {
            services.AddFluentValidation(Assembly.GetExecutingAssembly());
            services.AddEF(configuration, sqlConectionSectionName);
            services.AddCQRS(Assembly.GetExecutingAssembly());
        }
    }
}