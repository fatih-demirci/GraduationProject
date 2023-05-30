using Core.Persistence.Paging;
using MessagePersistenceService.Application.Features.ChatCategories.Queries.GetAllChatCategory;
using Microsoft.AspNetCore.Mvc;

namespace MessagePersistenceService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatCategoriesController : BaseController
{
    [HttpGet("GetAllCountryCategories")]
    public async Task<IActionResult> GetAllCountryCategories([FromQuery] GetAllChatCategoryQueryRequest request)
    {
        IPaginate<GetAllChatCategoryResponseDto> result = await Mediator.Send(request);
        return Ok(result);
    }
}
