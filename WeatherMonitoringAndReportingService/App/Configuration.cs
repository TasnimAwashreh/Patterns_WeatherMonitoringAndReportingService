using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherMonitoringAndReportingService.Logic.Services;
using WeatherMonitoringAndReportingService.Logic.Subjects;

namespace WeatherMonitoringAndReportingService.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(Constants.ConfigFile)
                .Build();

            services.AddSingleton<IConfiguration>(config);
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<ISubject, Subject>()
                .AddScoped<IBotLoader, BotLoader>()

                .AddScoped<BotSystem>();
            return services;
        }
    }
}
