using MessageOnlineService.Api.IntegrationEvents.Events;

namespace MessageOnlineService.Api.Hubs;

public interface IMessageHub
{
    Task userJoined(UserJoinedIntegrationEvent userJoined);
    Task userLeaved(UserLeavedIntegrationEvent userLeaved);
    Task getConnectionId(string connectionId);
    Task receiveMessage(SendMessageIntegrationEvent sendMessage);
}
