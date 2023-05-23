using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using UniversityService.Application.Features.UniversityComments.Queries.GetAllUniversityComment;

namespace UniversityService.Api.Controllers;

public class UniversityCommentsController : ODataController
{
    private readonly IMediator _mediator;

    public UniversityCommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> GetUniversityComments(ODataQueryOptions<GetAllUniversityCommentResponseDto> options)
    {
        GetAllUniversityCommentQueryRequest request = new() { Options = options };
        List<GetAllUniversityCommentResponseDto> result = await _mediator.Send(request);
        return Ok(result);
    }
}
