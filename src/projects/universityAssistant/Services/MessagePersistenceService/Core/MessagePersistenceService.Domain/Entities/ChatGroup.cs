using Core.Persistence.Repositories;

namespace MessagePersistenceService.Domain.Entities;

public class ChatGroup : Entity
{
    public ChatGroup()
    {
        CreatedDate = DateTime.UtcNow;
    }

    public int Id { get; set; }
    public int ChatCategoryId { get; set; }
    public long? UserId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastMessageDate { get; set; }
    public bool Status { get; set; }

    public virtual ChatCategory ChatCategory { get; set; }
    public virtual User User { get; set; }
    public virtual List<OnlineInChat> OnlineInChats { get; set; }
    public virtual List<ChatGroupMessage> ChatGroupMessages { get; set; }
}