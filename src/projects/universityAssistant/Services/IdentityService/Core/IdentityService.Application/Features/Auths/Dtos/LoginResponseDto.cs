using IdentityService.Application.Features.Auths.Utils.Jwt;
using IdentityService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.Dtos
{
    public class LoginResponseDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshTokenDto RefreshToken { get; set; }
    }
}
