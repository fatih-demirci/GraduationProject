using Core.Persistence.Repositories;
using IdentityService.Domain.Enums;
using IdentityService.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
            RefreshTokens = new List<RefreshToken>();
            UserOperationClaims = new List<UserOperationClaim>();
        }
        public User(string email, string password, string ipAddress) : this()
        {
            Email = email;
            this.AddDomainEvent(new UserCreatedDomainEvent(this, password, ipAddress));
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool Status { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }
        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
