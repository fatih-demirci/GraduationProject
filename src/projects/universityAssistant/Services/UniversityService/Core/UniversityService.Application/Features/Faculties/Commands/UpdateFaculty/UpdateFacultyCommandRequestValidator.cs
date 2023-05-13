using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.Faculties.Commands.UpdateFaculty;

public class UpdateFacultyCommandRequestValidator : AbstractValidator<UpdateFacultyCommandRequest>
{
    public UpdateFacultyCommandRequestValidator()
    {
        RuleFor(i => i.Culture).MinimumLength(4);
        RuleFor(i => i.FacultyCultureId).GreaterThan(0);
        RuleFor(i => i.Name).MinimumLength(5);
        RuleFor(i => i.Id).GreaterThan(0);
    }
}
