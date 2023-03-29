using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Dtos
{
    public class UserUpdateResponseDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
    }
}
