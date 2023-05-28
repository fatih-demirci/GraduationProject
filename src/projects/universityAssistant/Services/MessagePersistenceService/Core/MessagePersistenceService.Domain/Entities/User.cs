using Core.Persistence.Repositories;

namespace MessagePersistenceService.Domain.Entities;

public class User : Entity
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public bool Status { get; set; }

    public virtual List<ChatGroupMessage> ChatGroupMessages { get; set; }
    public virtual List<OnlineInChat> OnlineInChats { get; set; }
    public virtual List<ChatGroup> ChatGroups { get; set; }
}