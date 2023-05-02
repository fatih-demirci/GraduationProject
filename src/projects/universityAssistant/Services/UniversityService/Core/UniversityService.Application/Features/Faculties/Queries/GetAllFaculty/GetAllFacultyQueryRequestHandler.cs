using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.Faculties.Queries.GetAllFaculty;

public class GetAllFacultyQueryRequestHandler : IRequestHandler<GetAllFacultyQueryRequest, IPaginate<GetAllFacultyResponseDto>>
{
    private readonly IFacultyRepository _facilityRepository;

    public GetAllFacultyQueryRequestHandler(IFacultyRepository facilityRepository)
    {
        _facilityRepository = facilityRepository;
    }

    public async Task<IPaginate<GetAllFacultyResponseDto>> Handle(GetAllFacultyQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<GetAllFacultyResponseDto> result = await _facilityRepository.GetListAsync<GetAllFacultyResponseDto>(index: request.Index, size: request.Size, cancellationToken: cancellationToken);
        return result;
    }
}
