using AutoMapper;
using Core.Persistence.Repositories;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;
using MessagePersistenceService.Persistence.Contexts;

namespace MessagePersistenceService.Persistence.Repositories;

public class OnlineInChatRepository : EfRepositoryBase<OnlineInChat, MessagePersistenceServiceContext>, IOnlineInChatRepository
{
    public OnlineInChatRepository(MessagePersistenceServiceContext context, IMapper mapper) : base(context, mapper)
    {
    }
}