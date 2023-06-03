namespace MessagePersistenceService.Application.Features.ChatGroups.Commands.AddChatGroup;

public class AddChatGroupResponse
{
    public int Id { get; set; }
    public int ChatCategoryId { get; set; }
    public long? UserId { get; set; }
    public string UserName { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public string Name { get; set; }
    public string ChatCategoryName { get; set; }
    public string ColorCode { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastMessageDate { get; set; }
}
