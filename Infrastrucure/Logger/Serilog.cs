using Serilog;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.Logger
{
    public static class Serilog
    {
        public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseSerilog((hostingContext, loggerConfiguration) =>
                    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));
        }
    }
}