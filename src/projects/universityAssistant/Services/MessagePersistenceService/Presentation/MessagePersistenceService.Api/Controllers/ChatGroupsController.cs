using MessagePersistenceService.Application.Features.ChatGroups.Commands.AddChatGroup;
using Microsoft.AspNetCore.Mvc;

namespace MessagePersistenceService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatGroupsController : BaseController
{
    [HttpPost("AddChatGroup")]
    public async Task<IActionResult> AddChatGroup(AddChatGroupCommandRequest request)
    {
        AddChatGroupResponse result = await Mediator.Send(request);
        return Ok(result);
    }
}