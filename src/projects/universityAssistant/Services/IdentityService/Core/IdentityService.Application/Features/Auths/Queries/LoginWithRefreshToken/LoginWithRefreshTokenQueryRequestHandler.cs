using Core.CrossCuttingConcerns.Exceptions;
using IdentityService.Application.Features.Auths.Dtos;
using IdentityService.Application.Features.Auths.Utils.Jwt;
using IdentityService.Application.Services.AuthServices;
using IdentityService.Application.Services.RefreshTokenServices;
using IdentityService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.Queries.LoginWithRefreshToken
{
    public class LoginWithRefreshTokenQueryRequestHandler : IRequestHandler<LoginWithRefreshTokenQueryRequest, LoginResponseDto>
    {
        IRefreshTokenService _refreshTokenService;
        IAuthService _authService;

        public LoginWithRefreshTokenQueryRequestHandler(IRefreshTokenService refreshTokenService, IAuthService authService)
        {
            _refreshTokenService = refreshTokenService;
            _authService = authService;
        }

        public async Task<LoginResponseDto> Handle(LoginWithRefreshTokenQueryRequest request, CancellationToken cancellationToken)
        {
            RefreshToken? refreshToken = await _refreshTokenService.GetByTokenAndIpAddressAsync(request.Token, request.IpAddress) ?? throw new BusinessException("Invalid Token");
            refreshToken.IsUsed = true;
            refreshToken.IsCancelled = false;
            AccessToken accessToken = await _authService.CreateAccessToken(refreshToken.User);
            RefreshToken refreshTokenNew = await _authService.CreateRefreshToken(refreshToken.User, request.IpAddress);

            _refreshTokenService.Update(refreshToken);
            await _authService.AddRefreshToken(refreshTokenNew);
            refreshToken.IsCancelled = false;
            await _refreshTokenService.SaveEntitiesAsync(cancellationToken);

            return new LoginResponseDto()
            {
                AccessToken = accessToken,
                RefreshToken = new RefreshTokenDto()
                {
                    Created = refreshTokenNew.Created,
                    Expires = refreshTokenNew.Expires,
                    Token = refreshTokenNew.Token
                },
            };
        }
    }
}
