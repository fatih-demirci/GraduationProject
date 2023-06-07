using Core.Persistence.Paging;
using MessagePersistenceService.Application.Features.OnlineInChats.Queries.GetAllOnlineInChat;
using Microsoft.AspNetCore.Mvc;

namespace MessagePersistenceService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OnlineInChatsController : BaseController
{
    [HttpGet("GetAllOnlineInChat")]
    public async Task<IActionResult> GetAllOnlineInChat([FromQuery] GetAllOnlineInChatQueryRequest request)
    {
        IPaginate<GetAllOnlineInChatResponseDto> result = await Mediator.Send(request);
        return Ok(result);
    }
}
