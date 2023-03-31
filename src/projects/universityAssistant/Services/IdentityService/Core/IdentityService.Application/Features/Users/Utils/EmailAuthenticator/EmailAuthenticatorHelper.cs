using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Features.Users.Utils.EmailAuthenticator
{
    public static class EmailAuthenticatorHelper
    {
        public static string CreateEmailActivationKey()
        {
            byte[] key = Encoding.UTF8.GetBytes(Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)));
            return Convert.ToBase64String(key);
        }

        public static string CreateEmailActivationCode()
        {
            string code = RandomNumberGenerator.GetInt32(Convert.ToInt32(Math.Pow(10, 6))).ToString().PadRight(6, '0');
            return code;
        }
    }
}
