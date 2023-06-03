using Core.Persistence.Repositories;

namespace MessagePersistenceService.Domain.Entities;

public class ChatCategory : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ColorCode { get; set; }
    public bool Status { get; set; }

    public virtual List<ChatGroup> ChatGroups { get; set; }
}