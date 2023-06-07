using Core.Persistence.Paging;
using MediatR;

namespace MessagePersistenceService.Application.Features.OnlineInChats.Queries.GetAllOnlineInChat;

public class GetAllOnlineInChatQueryRequest : IRequest<IPaginate<GetAllOnlineInChatResponseDto>>
{
    public int Index { get; set; }
    public int Size { get; set; }
    public int ChatGroupId { get; set; }
}