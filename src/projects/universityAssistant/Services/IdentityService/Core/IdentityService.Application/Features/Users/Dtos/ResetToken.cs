using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Dtos
{
    public class ResetToken
    {
        public ResetToken(long userId, string token)
        {
            UserId = userId;
            Token = token;
        }

        public long UserId { get; set; }
        public string Token { get; set; }
    }
}
