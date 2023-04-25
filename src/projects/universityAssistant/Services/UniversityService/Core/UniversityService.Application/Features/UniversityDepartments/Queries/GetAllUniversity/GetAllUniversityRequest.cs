using MediatR;
using Microsoft.AspNetCore.OData.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Features.UniversityDepartments.Dtos;

namespace UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversity;

public class GetAllUniversityRequest : IRequest<List<UniversityDto>>
{
    public ODataQueryOptions<UniversityDto> Options { get; set; }
}
