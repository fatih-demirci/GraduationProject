using MediatR;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.Universities.Queries.GetAllUniversity;

public class GetAllUniversityRequest : IRequest<List<GetAllUniversityResponseDto>>
{
    public ODataQueryOptions<GetAllUniversityResponseDto> Options { get; set; }
}
