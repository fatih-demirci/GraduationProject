using MessagePersistenceService.Application.Features.ChatGroupMessages.Commands.AddChatGroupMessage;
using Microsoft.AspNetCore.Mvc;

namespace MessagePersistenceService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatGroupMessagesController : BaseController
{
    [HttpPost("AddChatGroupMessage")]
    public async Task<IActionResult> AddChatGroupMessage([FromForm] AddChatGroupMessageCommandRequest request)
    {
        if (request.FormFiles == null || request.FormFiles.Count == 0)
        {
            request.FormFiles = Request.Form.Files;
        }

        AddChatGroupMessageResponse result = await Mediator.Send(request);
        return Ok(result);
    }
}
