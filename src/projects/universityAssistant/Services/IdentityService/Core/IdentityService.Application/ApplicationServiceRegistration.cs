﻿using IdentityService.Application.Features.Auths.DomainEventHandlers;
using IdentityService.Application.Features.Auths.Rules;
using IdentityService.Application.Features.Auths.Utils.Hashing;
using IdentityService.Application.Features.Auths.Utils.Jwt;
using IdentityService.Application.Services.AuthServices;
using IdentityService.Application.Services.RefreshTokenServices;
using IdentityService.Application.Services.UserOperationClaimServices;
using IdentityService.Domain.Events;
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
            services.AddScoped<ITokenHelper, TokenHelper>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IRefreshTokenService, RefreshTokenManager>();
            services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();

            return services;
        }
    }
}
