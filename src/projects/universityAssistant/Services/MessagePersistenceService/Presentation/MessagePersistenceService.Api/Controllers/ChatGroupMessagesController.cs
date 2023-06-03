using Core.Persistence.Paging;
using MessagePersistenceService.Application.Features.ChatGroupMessages.Commands.AddChatGroupMessage;
using MessagePersistenceService.Application.Features.ChatGroupMessages.Queries.GetAllChatGroupMessage;
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

    [HttpGet("GetAllChatGroupMessage")]
    public async Task<IActionResult> GetAllChatGroupMessage([FromQuery] GetAllChatGroupMessageQueryRequest request)
    {
        IPaginate<GetAllChatGroupMessageResponseDto> result = await Mediator.Send(request);
        return Ok(result);
    }
}
