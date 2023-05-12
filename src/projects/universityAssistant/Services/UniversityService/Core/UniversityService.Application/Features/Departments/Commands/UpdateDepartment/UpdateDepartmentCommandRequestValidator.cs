using FluentValidation;

namespace UniversityService.Application.Features.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandRequestValidator : AbstractValidator<UpdateDepartmentCommandRequest>
{
    public UpdateDepartmentCommandRequestValidator()
    {
        RuleFor(i => i.Culture).NotNull().MinimumLength(4);
        RuleFor(i => i.Name).NotNull().MinimumLength(5);
    }
}