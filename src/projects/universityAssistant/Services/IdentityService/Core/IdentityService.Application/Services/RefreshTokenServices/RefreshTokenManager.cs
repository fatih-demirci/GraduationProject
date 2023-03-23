using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Services.RefreshTokenServices
{
    public class RefreshTokenManager : IRefreshTokenService
    {
        IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenManager(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> AddAsync(RefreshToken refreshToken)
        {
            _refreshTokenRepository.Add(refreshToken);
            await _refreshTokenRepository.UnitOfWork.SaveEntitiesAsync();
            return refreshToken;
        }
    }
}
