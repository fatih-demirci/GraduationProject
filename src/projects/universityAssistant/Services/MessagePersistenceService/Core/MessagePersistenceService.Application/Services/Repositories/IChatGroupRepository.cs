using Core.Persistence.Repositories;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Application.Services.Repositories;

public interface IChatGroupRepository : IReadRepository<ChatGroup>, IWriteRepository<ChatGroup>
{
}