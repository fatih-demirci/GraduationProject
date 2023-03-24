using Core.Persistence.Repositories;
using IdentityService.Application.Services.Repositories;
using IdentityService.Domain.Entities;
using IdentityService.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, IdentityServiceContext>, IUserRepository
    {
        public UserRepository(IdentityServiceContext context) : base(context)
        {
        }
    }
}
