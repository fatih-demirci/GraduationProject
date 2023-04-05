using IdentityService.Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.ResetPassword
{
    public class ResetPasswordCommandRequest : IRequest<ResetPasswordResponseDto>
    {
        public long UserId { get; set; }
        public string ResetToken { get; set; }
        public string Password { get; set; }
    }
}
