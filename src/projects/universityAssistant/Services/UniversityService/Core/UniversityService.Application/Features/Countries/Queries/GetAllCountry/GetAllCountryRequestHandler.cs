using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.Countries.Queries.GetAllCountry;

public class GetAllCountryRequestHandler : IRequestHandler<GetAllCountryRequest, IPaginate<GetAllCountryResponseDto>>
{
    private readonly ICountryRepository _countryRepository;

    public GetAllCountryRequestHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<IPaginate<GetAllCountryResponseDto>> Handle(GetAllCountryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<GetAllCountryResponseDto> result = await _countryRepository.GetListAsync<GetAllCountryResponseDto>(index: request.Index, size: request.Size, cancellationToken: cancellationToken);
        return result;
    }
}
