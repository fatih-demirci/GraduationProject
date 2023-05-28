using Core.Persistence.Repositories;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Application.Services.Repositories;

public interface IChatCategoryRepository : IReadRepository<ChatCategory>, IWriteRepository<ChatCategory>
{
}