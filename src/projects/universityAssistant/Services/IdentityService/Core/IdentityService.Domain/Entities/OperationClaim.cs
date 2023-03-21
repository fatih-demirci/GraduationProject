using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    public class OperationClaim : Entity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
