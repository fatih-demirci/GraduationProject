using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityService.Application.Features.Universities.Commands.AddUniversity;

namespace UniversityService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostUniversitiesController : BaseController
{
    [HttpPost("AddUniversity")]
    public async Task<IActionResult> AddUniversity(AddUniversityCommandRequest request)
    {
        AddUniversityResponse result = await Mediator.Send(request);

        return Ok(result);
    }
}
