using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityService.Application.Features.Departments.Commands.AddDepartment;
using UniversityService.Application.Features.Departments.Commands.UpdateDepartment;
using UniversityService.Application.Features.Departments.Queries.GetAllDepartment;

namespace UniversityService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : BaseController
{
    [HttpGet("GetAllDepartment")]
    public async Task<IActionResult> GetAllDepartment([FromQuery] GetAllDepartmentQueryRequest request)
    {
        IPaginate<GetAllDepartmentResponseDto> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("AddDepartment")]
    public async Task<IActionResult> AddDepartment(AddDepartmentCommandRequest request)
    {
        AddDepartmentResponse result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("UpdateDepartment")]
    public async Task<IActionResult> UpdateDepartment(UpdateDepartmentCommandRequest request)
    {
        UpdateDepartmentResponse result = await Mediator.Send(request);
        return Ok(result);
    }
}
