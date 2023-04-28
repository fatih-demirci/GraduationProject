using Core.Persistence.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityService.Application.Features.Countries.Queries.GetAllCountry;

namespace UniversityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        [HttpGet("GetAllCountry")]
        public async Task<IActionResult> GetAllCountry([FromQuery] GetAllCountryRequest request)
        {
            IPaginate<GetAllCountryResponseDto> result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
