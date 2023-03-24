using IdentityService.Application.Features.Auths.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.Commands.Register
{
    public class RegisterCommandRequest : IRequest<LoginResponseDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? IpAddress { get; set; }
    }
}
