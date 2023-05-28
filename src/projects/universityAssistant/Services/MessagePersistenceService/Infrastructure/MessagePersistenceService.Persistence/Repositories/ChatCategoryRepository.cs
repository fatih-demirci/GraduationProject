using AutoMapper;
using Core.Persistence.Repositories;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;
using MessagePersistenceService.Persistence.Contexts;

namespace MessagePersistenceService.Persistence.Repositories;

public class ChatCategoryRepository : EfRepositoryBase<ChatCategory, MessagePersistenceServiceContext>, IChatCategoryRepository
{
    public ChatCategoryRepository(MessagePersistenceServiceContext context, IMapper mapper) : base(context, mapper)
    {
    }
}