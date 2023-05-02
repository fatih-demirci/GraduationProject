using Core.Persistence.Paging;
using MediatR;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.Proviences.Queries.GetAllProvienceByCountryId;

public class GetAllProvienceByCountryIdQueryRequestHandler : IRequestHandler<GetAllProvienceByCountryIdQueryRequest, IPaginate<GetAllProvienceByCountryIdResponseDto>>
{
    private readonly IProvienceRepository _provienceRepository;

    public GetAllProvienceByCountryIdQueryRequestHandler(IProvienceRepository provienceRepository)
    {
        _provienceRepository = provienceRepository;
    }

    public async Task<IPaginate<GetAllProvienceByCountryIdResponseDto>> Handle(GetAllProvienceByCountryIdQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<GetAllProvienceByCountryIdResponseDto> result = await _provienceRepository.GetListAsync<GetAllProvienceByCountryIdResponseDto>(i => i.CountryId == request.CountryId, index: request.Index, size: request.Size);
        return result;
    }
}
