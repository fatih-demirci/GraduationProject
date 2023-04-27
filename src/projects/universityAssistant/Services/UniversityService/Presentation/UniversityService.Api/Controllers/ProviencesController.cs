using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityService.Application.Features.Proviences.Queries.GetAllProvienceByCountryId;

namespace UniversityService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProviencesController : BaseController
{
    [HttpGet("GetAllProvienceByCountryId")]
    public async Task<IActionResult> GetAllProvienceByCountryId([FromQuery] GetAllProvienceByCountryIdRequest request)
    {
        IPaginate<GetAllProvienceByCountryIdResponseDto> result = await Mediator.Send(request);
        return Ok(result);
    }
}
