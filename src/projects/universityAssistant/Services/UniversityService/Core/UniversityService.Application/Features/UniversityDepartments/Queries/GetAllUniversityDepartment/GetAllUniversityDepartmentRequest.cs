using MediatR;

namespace UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversityDepartment;

public class GetAllUniversityDepartmentRequest : IRequest<IQueryable<GetAllUniversityDepartmentResponseDto>>
{
}
