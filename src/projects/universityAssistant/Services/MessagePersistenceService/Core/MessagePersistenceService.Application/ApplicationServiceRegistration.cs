using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using MessagePersistenceService.Application.Features.ChatGroupMessages.Rules;
using MessagePersistenceService.Application.Features.ChatGroups.Rules;
using MessagePersistenceService.Application.Services.ChatGroupServices;
using MessagePersistenceService.Application.Services.HttpContextAccessorServices;
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
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IHttpContextAccessorService, HttpContextAccessorManager>();
        services.AddScoped<IChatGroupService, ChatGroupManager>();

        services.AddScoped<ChatGroupBusinessRules>();
        services.AddScoped<ChatGroupMessageBusinessRules>();

        return services;
    }
}
