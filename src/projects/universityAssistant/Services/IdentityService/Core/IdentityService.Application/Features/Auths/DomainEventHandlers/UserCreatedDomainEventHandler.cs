using IdentityService.Application.Features.Auths.Rules;
using IdentityService.Application.Features.Auths.Utils.Hashing;
using IdentityService.Domain.Entities;
using IdentityService.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Auths.DomainEventHandlers
{
    public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
    {
        private readonly AuthBusinessRules _authBusinessRules;

        public UserCreatedDomainEventHandler(AuthBusinessRules authBusinessRules)
        {
            _authBusinessRules = authBusinessRules;
        }

        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _authBusinessRules.EmailAddressCanNotBeDuplicated(notification.User.Email);
            await _authBusinessRules.UserNameCanNotBeDuplicated(notification.User.UserName);

            HashingHelper.CreatePasswordHash(notification.Password, out byte[] passwordHash, out byte[] passwordSalt);
            notification.User.PasswordHash = passwordHash;
            notification.User.PasswordSalt = passwordSalt;

            UserOperationClaim userOperationClaim = new() { UserId = notification.User.Id, OperationClaimId = 1 };
            notification.User.UserOperationClaims.Add(userOperationClaim);
        }
    }
}
