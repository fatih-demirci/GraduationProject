﻿using EventBus.Base.Events;

namespace NotificationService.Api.IntegrationEvents.Events
{
    public class SendEmailIntegrationEvent : IntegrationEvent
    {
        public SendEmailIntegrationEvent(string toEmail, string subject, string htmlBody, string toFullName)
        {
            ToEmail = toEmail;
            Subject = subject;
            HtmlBody = htmlBody;
            ToFullName = toFullName;
        }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
        public string ToFullName { get; set; }
    }
}
