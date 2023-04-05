using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using IdentityService.Application.Features.Auths.DomainEventHandlers;
using IdentityService.Application.Features.Auths.Rules;
using IdentityService.Application.Features.Auths.Utils.Jwt;
using IdentityService.Application.Features.Users.Rules;
using IdentityService.Application.Services.AuthServices;
using IdentityService.Application.Services.RefreshTokenServices;
using IdentityService.Application.Services.UserOperationClaimServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(i => i.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehavior<,>));

            services.AddScoped<ITokenHelper, TokenHelper>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IRefreshTokenService, RefreshTokenManager>();
            services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<UserBusinessRules>();

            services.AddScoped<UserCreatedDomainEventHandler>();
            return services;
        }
    }
}
