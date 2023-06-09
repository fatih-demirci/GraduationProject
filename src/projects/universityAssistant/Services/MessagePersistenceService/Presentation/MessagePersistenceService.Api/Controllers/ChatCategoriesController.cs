using Core.Persistence.Paging;
using MessagePersistenceService.Application.Features.ChatCategories.Queries.GetAllChatCategory;
using Microsoft.AspNetCore.Mvc;

namespace MessagePersistenceService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatCategoriesController : BaseController
{
    [HttpGet("GetAllChatCategory")]
    public async Task<IActionResult> GetAllChatCategory([FromQuery] GetAllChatCategoryQueryRequest request)
    {
        IPaginate<GetAllChatCategoryResponseDto> result = await Mediator.Send(request);
        return Ok(result);
    }
}
