using EventBus.Base.Abstraction;
using MessageOnlineService.Api.IntegrationEvents.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace MessageOnlineService.Api.Hubs;

public class MessageHub : Hub<IMessageHub>
{
    private readonly IEventBus _eventBus;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MessageHub(IEventBus eventBus, IHttpContextAccessor httpContextAccessor)
    {
        _eventBus = eventBus;
        _httpContextAccessor = httpContextAccessor;
    }

    [Authorize]
    public async Task AddToGroup(int chatGroupId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatGroupId.ToString());
        long userId = long.Parse(_httpContextAccessor.HttpContext!.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
        await _eventBus.Publish(new AddToGroupIntegrationEvent(chatGroupId, userId, Context.ConnectionId));
    }

    [Authorize]
    public async Task RemoveFromGroup()
    {
        await _eventBus.Publish(new UserDisconnectedIntegrationEvent(Context.ConnectionId));
    }

    public override async Task OnConnectedAsync()
    {
        await Clients.Caller.getConnectionId(Context.ConnectionId);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await _eventBus.Publish(new UserDisconnectedIntegrationEvent(Context.ConnectionId));
    }
}
