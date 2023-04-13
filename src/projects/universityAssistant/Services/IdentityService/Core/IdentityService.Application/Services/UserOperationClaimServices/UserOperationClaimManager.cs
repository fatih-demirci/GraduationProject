using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Services.UserOperationClaimServices
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public UserOperationClaimManager(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(long userId)
        {
            var userOperationClaims = (await _userOperationClaimRepository.GetListAsync(i => i.UserId == userId, include: i => i.Include(i => i.OperationClaim))).Items;
            var operationClaims = userOperationClaims.Select(i => i.OperationClaim).ToList();
            return operationClaims;
        }
    }
}
