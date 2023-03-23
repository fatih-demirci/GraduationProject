using Core.Persistence.Repositories;
using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Services.Repositories
{
    public interface IUserOperationClaimRepository : IReadRepository<UserOperationClaim>, IWriteRepository<UserOperationClaim>
    {
    }
}
