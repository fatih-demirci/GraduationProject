using FluentValidation;

namespace UniversityService.Application.Features.Faculties.Commands.AddFaculty;

public class AddFacultyCommandRequestValidator : AbstractValidator<AddFacultyCommandRequest>
{
    public AddFacultyCommandRequestValidator()
    {
        RuleForEach(x => x.AddFacultyCommandRequestFaculties)
            .ChildRules(y => y.RuleForEach(z => z.FacultyCultures)
            .ChildRules(d =>
        {
            d.RuleFor(fc => fc.Culture).MinimumLength(4);
            d.RuleFor(fc => fc.Name).MinimumLength(5);
        }));
    }
}