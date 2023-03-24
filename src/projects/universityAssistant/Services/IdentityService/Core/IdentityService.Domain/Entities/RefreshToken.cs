using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    public class RefreshToken : Entity
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public bool IsUsed { get; set; }
        public bool IsCancelled { get; set; }
        public virtual User User { get; set; }
    }
}
