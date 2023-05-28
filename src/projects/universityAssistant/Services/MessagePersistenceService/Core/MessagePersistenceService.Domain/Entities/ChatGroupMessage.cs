using Core.Persistence.Repositories;

namespace MessagePersistenceService.Domain.Entities;

public class ChatGroupMessage : Entity
{
    public Guid Id { get; set; }
    public int ChatGroupId { get; set; }
    public long? UserId { get; set; }
    public string Message { get; set; }
    public DateTime SendingDate { get; set; }
    public bool Status { get; set; }

    public virtual ChatGroup ChatGroup { get; set; }
    public virtual User User { get; set; }
    public virtual List<ChatGroupMessageUrl> ChatGroupMessageUrls { get; set; }
}