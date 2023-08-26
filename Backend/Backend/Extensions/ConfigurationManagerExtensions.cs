using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Backend.Extensions
{
    public static class ConfigurationManagerExtensions
    {
        public static void RegisterConfigurationManager(this IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddSingleton(configuration);
        }
    }
}
