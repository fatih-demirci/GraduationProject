using IdentityService.Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.Update
{
    public class UserUpdateCommandRequest : IRequest<UserUpdateResponseDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
