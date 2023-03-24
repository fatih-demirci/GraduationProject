using Core.Persistence.Repositories;
using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Services.RefreshTokenServices
{
    public interface IRefreshTokenService : IUnitOfWork
    {
        RefreshToken Add(RefreshToken refreshToken);
        Task<List<RefreshToken>> GetAllByUserIdNotUsed(long userId);
        Task<RefreshToken?> GetByTokenAndIpAddressAsync(string token, string ipAddress);
        RefreshToken Update(RefreshToken refreshToken);
    }
}
