using Microsoft.AspNetCore.Mvc;
using UniversityService.Application.Features.UniversityComments.Commands.AddUniversityCommand;
using UniversityService.Application.Features.UniversityComments.Commands.AddUniversityComment;

namespace UniversityService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostUniversityCommentsController : BaseController
{
    [HttpPost("AddUniversityComment")]
    public async Task<IActionResult> AddUniversityComment([FromForm] AddUniversityCommentCommandRequest request)
    {
        if (request.FormFiles == null || request.FormFiles.Count == 0)
        {
            request.FormFiles = Request.Form.Files;
        }

        AddUniversityCommentResponse result = await Mediator.Send(request);
        return Ok(result);
    }
}
