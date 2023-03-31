using Core.CrossCuttingConcerns.Caching;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns
{
    public static class CrossCuttingConcernServiceRegistration
    {
        public static IServiceCollection AddCrossCuttingConcernServices(this IServiceCollection services)
        {
            services.AddScoped<ICacheService, CacheManager>();

            return services;
        }
    }
}
