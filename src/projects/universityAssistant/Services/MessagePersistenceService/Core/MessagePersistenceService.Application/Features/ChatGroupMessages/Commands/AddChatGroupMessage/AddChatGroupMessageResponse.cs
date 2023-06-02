namespace MessagePersistenceService.Application.Features.ChatGroupMessages.Commands.AddChatGroupMessage;

public class AddChatGroupMessageResponse
{
    public Guid Id { get; set; }
    public int ChatGroupId { get; set; }
    public long? UserId { get; set; }
    public string UserName { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public string Message { get; set; }
    public DateTime SendingDate { get; set; }

    public List<AddChatGroupMessageResponseChatGroupMessageUrl> ChatGroupMessageUrls { get; set; }
}

public class AddChatGroupMessageResponseChatGroupMessageUrl
{
    public int Id { get; set; }
    public string Url { get; set; }
    public string FileNameForStorage { get; set; }
    public string Type { get; set; }
}