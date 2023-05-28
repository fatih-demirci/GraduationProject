using Core.Persistence.Repositories;

namespace MessagePersistenceService.Domain.Entities;

public class OnlineInChat : Entity
{
    public int Id { get; set; }
    public long? UserId { get; set; }
    public int ChatGroupId { get; set; }
    public string ConnectionId { get; set; }

    public virtual User User { get; set; }
    public virtual ChatGroup ChatGroup { get; set; }
}