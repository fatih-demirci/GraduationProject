using IdentityService.Application.Features.Auths.Commands.Register;
using IdentityService.Application.Features.Auths.Dtos;
using IdentityService.Application.Features.Auths.Queries.Login;
using IdentityService.Application.Features.Auths.Queries.LoginWithRefreshToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommandRequest registerCommandRequest)
        {
            registerCommandRequest.IpAddress = GetIpAddress();
            LoginResponseDto result = await Mediator.Send(registerCommandRequest);
            return Created("", result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQueryRequest loginQueryRequest)
        {
            loginQueryRequest.IpAddress = GetIpAddress();
            LoginResponseDto result = await Mediator.Send(loginQueryRequest);
            return Ok(result);
        }

        [HttpPost("LoginWithRefreshToken")]
        public async Task<IActionResult> LoginWithRefreshToken([FromBody] LoginWithRefreshTokenQueryRequest loginWithRefreshTokenQueryRequest)
        {
            loginWithRefreshTokenQueryRequest.IpAddress = GetIpAddress();
            LoginResponseDto result = await Mediator.Send(loginWithRefreshTokenQueryRequest);
            return Ok(result);
        }
    }
}
