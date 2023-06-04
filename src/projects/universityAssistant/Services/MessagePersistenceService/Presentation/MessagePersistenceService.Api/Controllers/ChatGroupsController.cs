using Core.Persistence.Paging;
using MessagePersistenceService.Application.Features.ChatGroups.Commands.AddChatGroup;
using MessagePersistenceService.Application.Features.ChatGroups.Queries.GetAllChatGroup;
using MessagePersistenceService.Application.Features.ChatGroups.Queries.GetByIdChatGroup;
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

    [HttpGet("GetAllChatGroup")]
    public async Task<IActionResult> GetAllChatGroup([FromQuery] GetAllChatGroupQueryRequest request)
    {
        IPaginate<GetAllChatGroupResponseDto> result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetByIdChatGroup")]
    public async Task<IActionResult> GetByIdChatGroup([FromQuery] GetByIdChatGroupQueryRequest request)
    {
        GetByIdChatGroupResponseDto result = await Mediator.Send(request);
        return Ok(result);
    }
}