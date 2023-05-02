using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using UniversityService.Application.Features.Universities.Queries.GetAllUniversity;

namespace UniversityService.Api.Controllers;

public class UniversitiesController : ODataController
{
    private readonly IMediator _mediator;

    public UniversitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> GetUniversities(ODataQueryOptions<GetAllUniversityResponseDto> options)
    {
        GetAllUniversityQueryRequest request = new()
        {
            Options = options
        };

        List<GetAllUniversityResponseDto> result = await _mediator.Send(request);

        return Ok(result);
    }
}
