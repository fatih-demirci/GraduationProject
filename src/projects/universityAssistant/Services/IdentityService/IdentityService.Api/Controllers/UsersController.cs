using IdentityService.Application.Features.Users.Commands.ConfirmEmailAddress;
using IdentityService.Application.Features.Users.Commands.SendEmailConfirmation;
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

        [HttpGet("SendEmailConfirmation")]
        public async Task<IActionResult> SendEmailConfirmation([FromQuery] SendEmailConfirmationCommandRequest request)
        {
            SendEmailConfirmationResponseDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("ConfirmEmailAddressWithKeyOrCode")]
        public async Task<IActionResult> ConfirmEmailAddressWithKeyOrCode([FromQuery] ConfirmEmailAddressWithKeyOrCodeRequest request)
        {
            ConfirmEmailAddressWithKeyOrCodeResponseDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
