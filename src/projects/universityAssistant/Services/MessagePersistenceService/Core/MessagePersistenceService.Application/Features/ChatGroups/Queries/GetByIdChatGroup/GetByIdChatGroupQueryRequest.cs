using MediatR;

namespace MessagePersistenceService.Application.Features.ChatGroups.Queries.GetByIdChatGroup;

public class GetByIdChatGroupQueryRequest : IRequest<GetByIdChatGroupResponseDto>
{
    public int Id { get; set; }
}