using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Features.UniversityDepartments.Dtos;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversity;

public class GetAllUniversityRequestHandler : IRequestHandler<GetAllUniversityRequest, List<UniversityDto>>
{
    private readonly IUniversityRepository _universityRepository;

    public GetAllUniversityRequestHandler(IUniversityRepository universityRepository)
    {
        _universityRepository = universityRepository;
    }

    public async Task<List<UniversityDto>> Handle(GetAllUniversityRequest request, CancellationToken cancellationToken)
    {
        List<UniversityDto> result = await _universityRepository.GetListAsync<UniversityDto>(request.Options);
        return result;
    }
}
