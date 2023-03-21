using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Extensions
{
    public static class HostExtension
    {
        public static async Task<IHost> MigrateDbContext<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder)
                where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();
                try
                {
                    logger.LogInformation($"Migrating database associated with context {typeof(TContext).Name}");

                    var rety = Policy.Handle<SqlException>().WaitAndRetryAsync(new TimeSpan[]
                    {
                        TimeSpan.FromSeconds(3),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(8),
                    });

                    await rety.ExecuteAsync(async () => await InvokeSeeder(seeder, context, services));

                    logger.LogInformation("Migrated database");
                }
                catch (Exception ex)
                {
                    logger.LogError($"An error occured while migration the database used on context {typeof(TContext).Name}");
                }
            }

            return host;
        }

        private static async Task InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services) where TContext : DbContext
        {
            await context.Database.EnsureCreatedAsync();
            await context.Database.MigrateAsync();

            seeder(context, services);
        }
    }
}
