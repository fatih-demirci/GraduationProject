using Core.Persistence.Paging;
using MediatR;
using MessagePersistenceService.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MessagePersistenceService.Application.Features.OnlineInChats.Queries.GetAllOnlineInChat;

public class GetAllOnlineInChatQueryRequestHandler : IRequestHandler<GetAllOnlineInChatQueryRequest, IPaginate<GetAllOnlineInChatResponseDto>>
{
    private readonly IOnlineInChatRepository _onlineInChatRepository;

    public GetAllOnlineInChatQueryRequestHandler(IOnlineInChatRepository onlineInChatRepository)
    {
        _onlineInChatRepository = onlineInChatRepository;
    }

    public async Task<IPaginate<GetAllOnlineInChatResponseDto>> Handle(GetAllOnlineInChatQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<GetAllOnlineInChatResponseDto> response = await _onlineInChatRepository.GetListAsync<GetAllOnlineInChatResponseDto>(
            index: request.Index,
            size: request.Size,
            include: i => i.Include(i => i.User),
            predicate: i => i.ChatGroupId == request.ChatGroupId,
            distinctBy: i => i.UserName
            );

        return response;
    }
}
