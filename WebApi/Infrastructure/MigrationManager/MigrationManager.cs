using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;

namespace Infrastructure.MigrationManager
{
    public static class MigrationManager
    {
        private const int MaxRetries = 6;
        private const int RetryDelayMilliseconds = 10000;

        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using var appContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                bool migrationSucceeded = false;
                int retryCount = 0;

                while (!migrationSucceeded && retryCount < MaxRetries)
                {
                    try
                    {
                        appContext.Database.Migrate();
                        migrationSucceeded = true;
                    }
                    catch (Exception)
                    {
                        retryCount++;
                        Console.WriteLine($"Migration failed. Retrying... Attempt {retryCount}/{MaxRetries}");
                        Thread.Sleep(RetryDelayMilliseconds);
                    }
                }

                if (!migrationSucceeded)
                {
                    throw new ApplicationException("Migration failed after multiple retries.");
                }
            }

            return host;
        }
    }
}
