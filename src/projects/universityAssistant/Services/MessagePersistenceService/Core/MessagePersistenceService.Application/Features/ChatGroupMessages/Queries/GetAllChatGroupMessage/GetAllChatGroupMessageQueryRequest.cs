using Core.Persistence.Paging;
using MediatR;

namespace MessagePersistenceService.Application.Features.ChatGroupMessages.Queries.GetAllChatGroupMessage;

public class GetAllChatGroupMessageQueryRequest : IRequest<IPaginate<GetAllChatGroupMessageResponseDto>>
{
    public int Index { get; set; }
    public int Size { get; set; }
    public int ChatGroupId { get; set; }
    public bool Status { get; set; }
}