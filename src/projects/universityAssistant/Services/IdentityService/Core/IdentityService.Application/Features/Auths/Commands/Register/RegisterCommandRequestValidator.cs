using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.Commands.Register
{
    public class RegisterCommandRequestValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandRequestValidator()
        {
            RuleFor(i => i.Email).EmailAddress().MinimumLength(5);
            RuleFor(i => i.UserName).MinimumLength(5);
            RuleFor(i => i.Password).MinimumLength(8);
        }
    }
}
