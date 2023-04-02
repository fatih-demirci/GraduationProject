using EventBus.Base.Abstraction;
using NotificationService.Api.IntegrationEvents.Events;
using NotificationService.Api.Mailing;

namespace NotificationService.Api.IntegrationEvents.EventHandlers
{
    public class SendEmailIntegrationEventHandler : IIntegrationEventHandler<SendEmailIntegrationEvent>
    {
        private readonly IMailService _mailService;

        public SendEmailIntegrationEventHandler(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task Handle(SendEmailIntegrationEvent @event)
        {
            Mail mail = new()
            {
                Subject = @event.Subject,
                HtmlBody = @event.HtmlBody,
                ToFullName = @event.ToFullName,
                ToEmail = @event.ToEmail
            };

            await _mailService.SendAsync(mail);
        }
    }
}
