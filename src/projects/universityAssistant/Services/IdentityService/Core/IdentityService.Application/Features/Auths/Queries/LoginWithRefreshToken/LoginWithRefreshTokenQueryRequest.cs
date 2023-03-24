using IdentityService.Application.Features.Auths.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.Queries.LoginWithRefreshToken
{
    public class LoginWithRefreshTokenQueryRequest : IRequest<LoginResponseDto>
    {
        public string Token { get; set; }
        public string? IpAddress { get; set; }
    }
}
