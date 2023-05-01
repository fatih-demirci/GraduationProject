using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityService.Application.Features.Departments.Queries;

namespace UniversityService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : BaseController
{
    [HttpGet("GetAllDepartment")]
    public async Task<IActionResult> GetAllDepartment([FromQuery] GetAllDepartmentRequest request)
    {
        IPaginate<GetAllDepartmentResponseDto> result = await Mediator.Send(request);
        return Ok(result);
    }
}
