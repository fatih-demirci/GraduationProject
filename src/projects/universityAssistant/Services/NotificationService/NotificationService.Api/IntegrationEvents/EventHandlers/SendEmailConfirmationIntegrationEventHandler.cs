using EventBus.Base.Abstraction;
using NotificationService.Api.IntegrationEvents.Events;

namespace NotificationService.Api.IntegrationEvents.EventHandlers
{
    public class SendEmailIntegrationEventHandler : IIntegrationEventHandler<SendEmailIntegrationEvent>
    {
        public Task Handle(SendEmailIntegrationEvent @event)
        {
            Console.WriteLine($"Email : {@event.Email} Title : {@event.Title} Body : {@event.Body}");
            return Task.CompletedTask;
        }
    }
}
