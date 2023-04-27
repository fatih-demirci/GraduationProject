using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.Universities.Queries.GetAllUniversity;

public class GetAllUniversityRequestHandler : IRequestHandler<GetAllUniversityRequest, List<GetAllUniversityResponseDto>>
{
    private readonly IUniversityRepository _universityRepository;

    public GetAllUniversityRequestHandler(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }

    public async Task<List<GetAllUniversityResponseDto>> Handle(GetAllUniversityRequest request, CancellationToken cancellationToken)
    {
        List<GetAllUniversityResponseDto> result = await _universityRepository.GetListAsync<GetAllUniversityResponseDto>(request.Options);
        return result;
    }
}
