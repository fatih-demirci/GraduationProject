using Core.Persistence.Repositories;
using IdentityService.Application.Features.Auths.Utils.Jwt;
using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Services.AuthServices
{
    public interface IAuthService : IUnitOfWork
    {
        Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
        Task<AccessToken> CreateAccessToken(User user);
        Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
    }
}
