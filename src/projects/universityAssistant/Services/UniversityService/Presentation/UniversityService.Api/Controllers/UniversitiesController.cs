using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using UniversityService.Application.Features.UniversityDepartments.Dtos;
using UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversity;

namespace UniversityService.Api.Controllers;

public class UniversitiesController : ODataController
{
    private readonly IMediator _mediator;

    public UniversitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> GetUniversities(ODataQueryOptions<UniversityDto> options)
    {
        GetAllUniversityRequest request = new()
        {
            Options = options
        };

        List<UniversityDto> result = await _mediator.Send(request);

        return Ok(result);
    }
}
