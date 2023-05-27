using MessagePersistenceService.Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;

namespace MessagePersistenceService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserManager>();

        return services;
    }
}
