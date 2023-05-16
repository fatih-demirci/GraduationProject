using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.Universities.Commands.AddUniversity;

public class AddUniversityCommandRequestValidator : AbstractValidator<AddUniversityCommandRequest>
{
    public AddUniversityCommandRequestValidator()
    {
        RuleFor(i => i.Address).MinimumLength(5);
        RuleFor(i => i.Phone).MinimumLength(7);
        RuleFor(i => i.Email).EmailAddress();
        RuleFor(i => i.ProvienceId).GreaterThan(0);
        RuleFor(i => i.Fax).MinimumLength(7);
        RuleFor(i => i.Website).MinimumLength(5);
        RuleFor(i => i.Name).MinimumLength(5);
        RuleFor(i => i.Type).InclusiveBetween((byte)0, (byte)1);
    }
}
