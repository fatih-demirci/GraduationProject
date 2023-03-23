using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Services.UserOperationClaimServices
{
    public interface IUserOperationClaimService
    {
        Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(long userId);
    }
}
