using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Commands.ResetPassword
{
    public class ResetPasswordCommandRequestValidator : AbstractValidator<ResetPasswordCommandRequest>
    {
        public ResetPasswordCommandRequestValidator()
        {
            RuleFor(i => i.Password).MinimumLength(8);
        }
    }
}
