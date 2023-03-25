using IdentityService.Application.Features.Users.Commands.Update;
using IdentityService.Application.Features.Users.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost("Update")]
        public async Task<IActionResult> Update(UserUpdateCommandRequest request)
        {
            UserUpdateResponseDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
