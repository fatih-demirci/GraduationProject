using MessagePersistenceService.Application.Services.UserServices;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MessagePersistenceService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(i => i.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IUserService, UserManager>();

        return services;
    }
}
