using Microsoft.AspNetCore.Mvc;
using UniversityService.Application.Features.UniversityDepartments.Commands.AddUniversityDepartment;

namespace UniversityService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversityDepartmentsPostController : BaseController
{
    [HttpPost("AddUniversityDepartment")]
    public async Task<IActionResult> AddUniversityDepartment(AddUniversityDepartmentCommandRequest request)
    {
        AddUniversityDepartmentResponse result = await Mediator.Send(request);
        return Ok(result);
    }
}
