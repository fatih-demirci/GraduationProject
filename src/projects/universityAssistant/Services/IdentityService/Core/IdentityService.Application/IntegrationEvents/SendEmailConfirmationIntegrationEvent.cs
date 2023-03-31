using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.IntegrationEvents
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
