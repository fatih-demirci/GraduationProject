namespace MessagePersistenceService.Application.Features.OnlineInChats.Queries.GetAllOnlineInChat;

public class GetAllOnlineInChatResponseDto
{
    public int Id { get; set; }
    public long? UserId { get; set; }
    public string UserName { get; set; }
    public string? ProfilePhotoUrl { get; set; }
}
