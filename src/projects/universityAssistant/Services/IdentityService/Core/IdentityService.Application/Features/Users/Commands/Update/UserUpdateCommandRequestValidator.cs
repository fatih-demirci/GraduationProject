using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.Update
{
    public class UserUpdateCommandRequestValidator : AbstractValidator<UserUpdateCommandRequest>
    {
        public UserUpdateCommandRequestValidator()
        {
            RuleFor(i => i.UserName).MinimumLength(5);
        }
    }
}
