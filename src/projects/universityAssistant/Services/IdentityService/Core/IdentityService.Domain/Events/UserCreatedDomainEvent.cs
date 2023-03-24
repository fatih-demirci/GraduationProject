using IdentityService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Events
{
    public class UserCreatedDomainEvent : INotification
    {
        public UserCreatedDomainEvent(User user, string password, string ipAddress)
        {
            User = user;
            Password = password;
            IpAddress = ipAddress;
        }
        public User User { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
    }
}
