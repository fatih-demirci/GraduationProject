using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityService.Application.Features.Faculties.Commands.AddFaculty;
using UniversityService.Application.Features.Faculties.Commands.UpdateFaculty;
using UniversityService.Application.Features.Faculties.Queries.GetAllFaculty;

namespace UniversityService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacultiesController : BaseController
{
    [HttpGet("GetAllFaculty")]
    public async Task<IActionResult> GetAllFaculty([FromQuery] GetAllFacultyQueryRequest request)
    {
        IPaginate<GetAllFacultyResponseDto> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("AddFaculty")]
    public async Task<IActionResult> GetFaculty(AddFacultyCommandRequest request)
    {
        AddFacultyResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("UpdateFaculty")]
    public async Task<IActionResult> UpdateFaculty(UpdateFacultyCommandRequest request)
    {
        UpdateFacultyResponse result = await Mediator.Send(request);
        return Ok(result);
    }
}
