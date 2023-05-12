using FluentValidation;

namespace UniversityService.Application.Features.Departments.Commands.AddDepartment;

public class AddDepartmentCommandRequestValidator : AbstractValidator<AddDepartmentCommandRequest>
{
    public AddDepartmentCommandRequestValidator()
    {
        RuleForEach(i => i.AddDepartmentCommandRequestDepartments)
            .ChildRules(x => x.RuleForEach(y => y.DepartmentCultures)
            .ChildRules(z =>
            {
                z.RuleFor(dc => dc.Culture).MinimumLength(4).NotNull();
                z.RuleFor(dc => dc.Name).MinimumLength(5).NotNull();
            }));
    }
}