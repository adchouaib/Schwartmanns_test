using System;
using Application.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class ServiceExtensions
	{
		public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));

			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IClientRepository, ClientRepository>();
			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<ISheetRepository, SheetRepository>();
			services.AddScoped<ICircleRepository, CircleRepository>();
			services.AddScoped<ILinesRepository, LinesRepository>();
		}
	}
}

