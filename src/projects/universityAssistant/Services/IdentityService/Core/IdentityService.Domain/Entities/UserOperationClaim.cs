using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    public class UserOperationClaim : Entity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long OperationClaimId { get; set; }
        public virtual User User { get; set; }
        public virtual OperationClaim OperationClaim { get; set; }
    }
}
