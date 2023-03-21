using IdentityService.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Persistence.Contexts
{
    public class IdentityServiceContextSeed
    {
        public async Task SeedAsync(IdentityServiceContext context, ILogger<IdentityServiceContextSeed> logger)
        {
            var policy = Policy.Handle<SqlException>().WaitAndRetryAsync(
                retryCount: 5,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timeSpan, retry, ctx) =>
                {
                    logger.LogWarning(exception, $"{nameof(IdentityServiceContextSeed)} Exception {exception.GetType} with message {exception.Message}");
                }
                );

            await policy.ExecuteAsync(() => ProcessSeeding(context, logger));
        }

        private async Task ProcessSeeding(IdentityServiceContext context, ILogger<IdentityServiceContextSeed> logger)
        {
            if (!context.OperationClaims.Any())
            {
                await context.OperationClaims.AddRangeAsync(GetPredefinedOperationClaims());

                context.SaveChanges();
            }
        }

        private List<OperationClaim> GetPredefinedOperationClaims()
        {
            return new List<OperationClaim> {
                new OperationClaim(){ Id = 1, Name = "user" },
                new OperationClaim(){ Id = 2, Name = "admin" },
                new OperationClaim(){ Id = 3, Name = "superadmin" }
            };
        }
    }
}
