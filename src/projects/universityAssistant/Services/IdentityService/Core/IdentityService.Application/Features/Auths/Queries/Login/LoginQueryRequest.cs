using IdentityService.Application.Features.Auths.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.Queries.Login
{
    public class LoginQueryRequest : IRequest<LoginResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? IpAddress { get; set; }
    }
}
