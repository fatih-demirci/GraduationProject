using MediatR;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversityDepartment;

public class GetAllUniversityDepartmentRequestHandler : IRequestHandler<GetAllUniversityDepartmentRequest, IQueryable<GetAllUniversityDepartmentResponseDto>>
{
    private readonly IUniversityDepartmentRepository _universityDepartmentRepository;

    public GetAllUniversityDepartmentRequestHandler(IUniversityDepartmentRepository universityDepartmentRepository)
    {
        _universityDepartmentRepository = universityDepartmentRepository;
    }

    public async Task<IQueryable<GetAllUniversityDepartmentResponseDto>> Handle(GetAllUniversityDepartmentRequest request, CancellationToken cancellationToken)
    {
        IQueryable<GetAllUniversityDepartmentResponseDto> result = await Task.FromResult(_universityDepartmentRepository.GetListAsyncIQueryable<GetAllUniversityDepartmentResponseDto>());
        return result;
    }
}
