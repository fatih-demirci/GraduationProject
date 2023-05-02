using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.Proviences.Queries.GetAllProvienceByCountryId;

public class GetAllProvienceByCountryIdQueryRequest : IRequest<IPaginate<GetAllProvienceByCountryIdResponseDto>>
{
    public int Index { get; set; }
    public int Size { get; set; }
    public int CountryId { get; set; }
}
