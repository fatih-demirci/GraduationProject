using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Utils.ResetTokenAuthenticator
{
    public static class ResetTokenAuthenticatorHelper
    {
        public static string CreateResetToken()
        {
            byte[] key = Encoding.UTF8.GetBytes(Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)));
            return Convert.ToBase64String(key);
        }
    }
}
