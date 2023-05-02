using MediatR;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversityDepartment;

public class GetAllUniversityDepartmentQueryRequestHandler : IRequestHandler<GetAllUniversityDepartmentQueryRequest, List<GetAllUniversityDepartmentResponseDto>>
{
    private readonly IUniversityDepartmentRepository _universityDepartmentRepository;

    public GetAllUniversityDepartmentQueryRequestHandler(IUniversityDepartmentRepository universityDepartmentRepository)
    {
        _universityDepartmentRepository = universityDepartmentRepository;
    }

    public async Task<List<GetAllUniversityDepartmentResponseDto>> Handle(GetAllUniversityDepartmentQueryRequest request, CancellationToken cancellationToken)
    {
        List<GetAllUniversityDepartmentResponseDto> result = await _universityDepartmentRepository.GetListAsync(request.Options!);
        return result;
    }
}
