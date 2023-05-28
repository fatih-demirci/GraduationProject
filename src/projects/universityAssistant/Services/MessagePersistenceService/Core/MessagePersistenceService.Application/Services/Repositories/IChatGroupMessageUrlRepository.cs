using Core.Persistence.Repositories;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Application.Services.Repositories;

public interface IChatGroupMessageUrlRepository : IReadRepository<ChatGroupMessageUrl>, IWriteRepository<ChatGroupMessageUrl>
{
}