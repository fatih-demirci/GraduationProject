using EventBus.Base.Events;

namespace NotificationService.Api.IntegrationEvents.Events
{
    public class SendEmailIntegrationEvent : IntegrationEvent
    {
        public SendEmailIntegrationEvent(string email, string title, string body)
        {
            Email = email;
            Title = title;
            Body = body;
        }

        public string Email { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
