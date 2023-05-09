using MediatR;

namespace UniversityService.Application.Features.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandRequest : IRequest<UpdateDepartmentResponse>
{
    public int Id { get; set; }
    public int DepartmentCultureId { get; set; }
    public string Culture { get; set; }
    public string Name { get; set; }
}