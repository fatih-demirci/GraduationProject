using Core.Application.Languages;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authorization
{
    public class RequestAuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestAuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<string>? roleClaims = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Role)?.Select(x => x.Value).ToList();

            if (roleClaims.IsNullOrEmpty()) throw new AuthenticationException(Messages.ClaimsNotFound);

            string? emailConfirmed = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "EmailConfirmed")?.Value;
            if (!bool.Parse(emailConfirmed)) throw new AuthorizationException(Messages.EmailAddressIsNotConfirmed);

            bool isNotMatchedARoleClaimWithRequestRoles =
                roleClaims!.FirstOrDefault(roleClaim => request.Roles.Any(role => role == roleClaim)).IsNullOrEmpty();
            if (isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationException(Messages.YouAreNotAuthorized);

            TResponse response = await next();
            return response;
        }
    }
}
