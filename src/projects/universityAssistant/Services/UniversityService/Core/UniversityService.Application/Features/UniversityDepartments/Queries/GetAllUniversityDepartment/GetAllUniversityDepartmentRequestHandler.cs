using MediatR;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversityDepartment;

public class GetAllUniversityDepartmentRequestHandler : IRequestHandler<GetAllUniversityDepartmentRequest, List<GetAllUniversityDepartmentResponseDto>>
{
    private readonly IUniversityDepartmentRepository _universityDepartmentRepository;

    public GetAllUniversityDepartmentRequestHandler(IUniversityDepartmentRepository universityDepartmentRepository)
    {
        _universityDepartmentRepository = universityDepartmentRepository;
    }

    public async Task<List<GetAllUniversityDepartmentResponseDto>> Handle(GetAllUniversityDepartmentRequest request, CancellationToken cancellationToken)
    {
        List<GetAllUniversityDepartmentResponseDto> result = await _universityDepartmentRepository.GetListAsync(request.Options!);
        return result;
    }
}
