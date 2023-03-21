using IdentityService.Application.Services.Repositories;
using IdentityService.Persistence.Contexts;
using IdentityService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityServiceContext>(options => options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString"), sqlServerOptionsAction: sqlOptions =>
            {
                //sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            }));
            return services;
        }
    }
}
