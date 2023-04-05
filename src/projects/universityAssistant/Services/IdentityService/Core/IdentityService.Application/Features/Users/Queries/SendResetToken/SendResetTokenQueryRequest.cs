using IdentityService.Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Queries.SendResetToken
{
    public class SendResetTokenQueryRequest : IRequest<SendResetTokenResponseDto>
    {
        public string Email { get; set; }
    }
}
