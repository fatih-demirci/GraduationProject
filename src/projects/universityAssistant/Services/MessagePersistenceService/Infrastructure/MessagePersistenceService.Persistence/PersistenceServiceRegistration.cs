using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Persistence.Contexts;
using MessagePersistenceService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessagePersistenceService.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MessagePersistenceServiceContext>(options => options.UseSqlServer(configuration.GetConnectionString("MessagePersistenceConnectionString"), sqlServerOptionsAction: sqlOptions =>
        {
            //sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        }));

        services.AddScoped<IChatCategoryRepository, ChatCategoryRepository>();
        services.AddScoped<IChatGroupMessageRepository, ChatGroupMessageRepository>();
        services.AddScoped<IChatGroupMessageUrlRepository, ChatGroupMessageUrlRepository>();
        services.AddScoped<IChatGroupRepository, ChatGroupRepository>();
        services.AddScoped<IOnlineInChatRepository, OnlineInChatRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}