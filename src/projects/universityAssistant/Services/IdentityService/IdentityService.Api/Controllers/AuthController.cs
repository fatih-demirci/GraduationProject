using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Test(int id)
        {
            return Ok($"OK : {id}");
        }
    }
}
