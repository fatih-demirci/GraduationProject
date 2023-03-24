using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Application.Services.RefreshTokenServices
{
    public class RefreshTokenManager : IRefreshTokenService
    {
        IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenManager(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return _refreshTokenRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }

        public RefreshToken Add(RefreshToken refreshToken)
        {
            _refreshTokenRepository.Add(refreshToken);
            return refreshToken;
        }

        public async Task<RefreshToken?> GetByTokenAndIpAddressAsync(string token, string ipAddress)
        {
            RefreshToken? refreshToken = await _refreshTokenRepository.GetAsync(
                i => i.Token == token
                && i.CreatedByIp == ipAddress
                && i.IsUsed == false
                && i.IsCancelled == false
                && i.Expires >= DateTime.UtcNow,
                include: i => i.Include(i => i.User));
            return refreshToken;
        }

        public RefreshToken Update(RefreshToken refreshToken)
        {
            refreshToken = _refreshTokenRepository.Update(refreshToken);
            return refreshToken;
        }

        public async Task<List<RefreshToken>> GetAllByUserIdNotUsed(long userId)
        {
            IList<RefreshToken> refreshTokens = (await _refreshTokenRepository.GetListAsync(i => i.UserId == userId
                                                                                              && i.IsUsed == false
                                                                                              && i.IsCancelled == false)).Items;

            return refreshTokens.ToList();
        }

    }
}
