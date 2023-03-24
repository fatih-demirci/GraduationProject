using IdentityService.Application.Features.Auths.Dtos;
using IdentityService.Application.Features.Auths.Rules;
using IdentityService.Application.Features.Auths.Utils.Jwt;
using IdentityService.Application.Services.AuthServices;
using IdentityService.Application.Services.RefreshTokenServices;
using IdentityService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.Queries.Login
{
    public class LoginQueryRequestHandler : IRequestHandler<LoginQueryRequest, LoginResponseDto>
    {
        AuthBusinessRules _authBusinessRules;
        IAuthService _authService;

        public LoginQueryRequestHandler(AuthBusinessRules authBusinessRules, IAuthService authService)
        {
            _authBusinessRules = authBusinessRules;
            _authService = authService;
        }

        public async Task<LoginResponseDto> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
        {
            User user = await _authBusinessRules.VerifyPassword(request.Email, request.Password);

            AccessToken accessToken = await _authService.CreateAccessToken(user);
            RefreshToken refreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
            refreshToken = await _authService.AddRefreshToken(refreshToken);
            await _authService.SaveEntitiesAsync(cancellationToken);
            LoginResponseDto response = new()
            {
                AccessToken = accessToken,
                RefreshToken = new RefreshTokenDto()
                {
                    Created = refreshToken.Created,
                    Expires = refreshToken.Expires,
                    Token = refreshToken.Token
                }
            };

            return response;
        }
    }
}
