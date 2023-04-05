using IdentityService.Application.Features.Users.Commands.ConfirmEmailAddress;
using IdentityService.Application.Features.Users.Commands.ResetPassword;
using IdentityService.Application.Features.Users.Commands.Update;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.Features.Users.Queries.CheckResetToken;
using IdentityService.Application.Features.Users.Queries.SendEmailConfirmation;
using IdentityService.Application.Features.Users.Queries.SendResetToken;
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
        public async Task<IActionResult> SendEmailConfirmation([FromQuery] SendEmailConfirmationQueryRequest request)
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

        [HttpPost("SendResetToken")]
        public async Task<IActionResult> SendResetToken(SendResetTokenQueryRequest request)
        {
            SendResetTokenResponseDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommandRequest request)
        {
            ResetPasswordResponseDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("CheckResetToken")]
        public async Task<IActionResult> CheckResetToken(CheckResetTokenQueryRequest request)
        {
            await Mediator.Send(request);
            return Ok();
        }
    }
}
