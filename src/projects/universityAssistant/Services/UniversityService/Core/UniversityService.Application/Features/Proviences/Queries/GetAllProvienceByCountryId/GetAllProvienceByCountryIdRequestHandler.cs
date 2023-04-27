using Core.Persistence.Paging;
using MediatR;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.Proviences.Queries.GetAllProvienceByCountryId;

public class GetAllProvienceByCountryIdRequestHandler : IRequestHandler<GetAllProvienceByCountryIdRequest, IPaginate<GetAllProvienceByCountryIdResponseDto>>
{
    private readonly IProvienceRepository _provienceRepository;

    public GetAllProvienceByCountryIdRequestHandler(IProvienceRepository provienceRepository)
    {
        _provienceRepository = provienceRepository;
    }

    public async Task<IPaginate<GetAllProvienceByCountryIdResponseDto>> Handle(GetAllProvienceByCountryIdRequest request, CancellationToken cancellationToken)
    {
        IPaginate<GetAllProvienceByCountryIdResponseDto> result = await _provienceRepository.GetListAsync<GetAllProvienceByCountryIdResponseDto>(i => i.CountryId == request.CountryId, index: request.Index, size: request.Size);
        return result;
    }
}
