using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.MigrationManager
{
    public static class MigrationManager
    {
        private static int _numberOfRetries;
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using var appContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception)
                {
                    if (_numberOfRetries < 6)
                    {
                        Thread.Sleep(10000);
                        _numberOfRetries++;
                        Console.WriteLine($"The server was not found or was not accessible. Retrying... #{_numberOfRetries}");
                        MigrateDatabase(host);
                    }
                    throw;
                }
            }
            return host;
        }
    }
}