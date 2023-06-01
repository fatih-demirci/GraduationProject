using Core.Persistence.Paging;
using MediatR;

namespace MessagePersistenceService.Application.Features.ChatGroups.Queries.GetAllChatGroup;

public class GetAllChatGroupQueryRequest : IRequest<IPaginate<GetAllChatGroupResponseDto>>
{
    public int Index { get; set; }
    public int Size { get; set; }
    public int ChatCategoryId { get; set; }
    public bool Status { get; set; }
}
