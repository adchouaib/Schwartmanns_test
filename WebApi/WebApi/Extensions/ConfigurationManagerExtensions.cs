using System;
namespace WebApi.Extensions
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

