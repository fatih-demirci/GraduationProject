using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.Departments.Queries;

public class GetAllDepartmentRequestHandler : IRequestHandler<GetAllDepartmentRequest, IPaginate<GetAllDepartmentResponseDto>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetAllDepartmentRequestHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<IPaginate<GetAllDepartmentResponseDto>> Handle(GetAllDepartmentRequest request, CancellationToken cancellationToken)
    {
        IPaginate<GetAllDepartmentResponseDto> result = await _departmentRepository.GetListAsync<GetAllDepartmentResponseDto>(index: request.Index, size: request.Size, cancellationToken: cancellationToken);
        return result;
    }
}
