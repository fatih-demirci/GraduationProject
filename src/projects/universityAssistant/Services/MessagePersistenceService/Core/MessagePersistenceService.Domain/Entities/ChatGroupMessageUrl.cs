using Core.Persistence.Repositories;

namespace MessagePersistenceService.Domain.Entities;

public class ChatGroupMessageUrl : Entity
{
    public int Id { get; set; }
    public Guid ChatGroupMessageId { get; set; }
    public string Url { get; set; }
    public string FileNameForStorage { get; set; }
    public string Type { get; set; }

    public virtual ChatGroupMessage ChatGroupMessage { get; set; }
}