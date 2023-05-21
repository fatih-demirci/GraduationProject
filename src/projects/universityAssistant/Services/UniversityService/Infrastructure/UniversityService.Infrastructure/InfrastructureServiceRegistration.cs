using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityService.Infrastructure.Handlers;
using UniversityService.Infrastructure.Storage;

namespace UniversityService.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFileService, FileManager>();

        services.AddTransient<HttpClientDelegatingHandler>();

        services.AddHttpClient("Files", c =>
        {
            c.BaseAddress = new Uri(configuration["Urls:Files"]!);
        }).AddHttpMessageHandler<HttpClientDelegatingHandler>();

        return services;
    }
}
