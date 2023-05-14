using FluentValidation;

namespace UniversityService.Application.Features.UniversityDepartments.Commands.AddUniversityDepartment;

public class AddUniversityDepartmentCommandRequestValidator : AbstractValidator<AddUniversityDepartmentCommandRequest>
{
    public AddUniversityDepartmentCommandRequestValidator()
    {
        RuleForEach(x => x.Universities)
            .ChildRules(y =>
            {
                y.RuleFor(u => u.UniversityId).GreaterThan(0);
                y.RuleForEach(u => u.Faculties).ChildRules(z =>
                {
                    z.RuleFor(u => u.FacultyId).GreaterThan(0);
                    z.RuleForEach(u => u.Departments).ChildRules(d =>
                    {
                        d.RuleFor(d => d.DepartmentId).GreaterThan(0);
                    });
                });
            });
    }
}
