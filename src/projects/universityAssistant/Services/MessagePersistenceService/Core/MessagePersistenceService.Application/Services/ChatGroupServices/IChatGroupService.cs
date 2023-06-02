namespace MessagePersistenceService.Application.Services.ChatGroupServices;

public interface IChatGroupService
{
    Task UpdateLastMessageDate(int id);
}
