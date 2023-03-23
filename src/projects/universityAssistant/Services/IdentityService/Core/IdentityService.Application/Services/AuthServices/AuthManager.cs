using IdentityService.Application.Features.Auths.Utils.Jwt;
using IdentityService.Application.Services.RefreshTokenServices;
using IdentityService.Application.Services.Repositories;
using IdentityService.Application.Services.UserOperationClaimServices;
using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Services.AuthServices
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public AuthManager(
            ITokenHelper tokenHelper,
            IUserOperationClaimService userOperationClaimService,
            IRefreshTokenService refreshTokenService)
        {
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenService.AddAsync(refreshToken);
            refreshToken.User = null;
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IList<OperationClaim> operationClaims = await _userOperationClaimService.GetOperationClaimsByUserIdAsync(user.Id);
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return Task.FromResult(refreshToken);
        }
    }
}
