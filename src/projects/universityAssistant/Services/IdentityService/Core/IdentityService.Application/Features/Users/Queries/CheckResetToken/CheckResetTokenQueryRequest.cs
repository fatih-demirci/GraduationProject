using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Queries.CheckResetToken
{
    public class CheckResetTokenQueryRequest : IRequest
    {
        public long UserId { get; set; }
        public string ResetToken { get; set; }
    }
}
