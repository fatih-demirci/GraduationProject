﻿using Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UniversityService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddMediatR(i => i.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehavior<,>));

        return services;
    }
}
