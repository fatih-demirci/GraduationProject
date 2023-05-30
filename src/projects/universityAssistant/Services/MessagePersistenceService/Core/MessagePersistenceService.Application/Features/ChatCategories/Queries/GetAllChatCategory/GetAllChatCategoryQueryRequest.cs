using Core.Persistence.Paging;
using MediatR;

namespace MessagePersistenceService.Application.Features.ChatCategories.Queries.GetAllChatCategory;

public class GetAllChatCategoryQueryRequest : IRequest<IPaginate<GetAllChatCategoryResponseDto>>
{
    public int Index { get; set; }
    public int Size { get; set; }
    public bool Status { get; set; }
}
