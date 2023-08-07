using System;
using System.Reflection;
using Application.Contracts;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
	public static class ServiceExtensions
	{
		public static void ConfigureApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddScoped(typeof(IUserService), typeof(UserService));
			services.AddScoped(typeof(IDashboardService), typeof(DashboardService));
		}
	}
}

