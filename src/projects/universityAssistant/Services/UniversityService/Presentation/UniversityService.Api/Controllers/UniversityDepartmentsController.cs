using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversityDepartment;

namespace UniversityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityDepartmentsController : ODataController
    {
        private readonly IMediator _mediator;

        public UniversityDepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUniversityDepartments(ODataQueryOptions<GetAllUniversityDepartmentResponseDto> options)
        {
            GetAllUniversityDepartmentRequest request = new()
            {
                Options = options
            };

            var items = await _mediator.Send(request);
            return Ok(items);
        }
    }
}
