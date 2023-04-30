using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.Faculties.Queries;

public class GetAllFacultyRequestHandler : IRequestHandler<GetAllFacultyRequest, IPaginate<GetAllFacultyResponseDto>>
{
    private readonly IFacultyRepository _facilityRepository;

    public GetAllFacultyRequestHandler(IFacultyRepository facilityRepository)
    {
        _facilityRepository = facilityRepository;
    }

    public async Task<IPaginate<GetAllFacultyResponseDto>> Handle(GetAllFacultyRequest request, CancellationToken cancellationToken)
    {
        IPaginate<GetAllFacultyResponseDto> result = await _facilityRepository.GetListAsync<GetAllFacultyResponseDto>(index: request.Index, size: request.Size, cancellationToken: cancellationToken);
        return result;
    }
}
