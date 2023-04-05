using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Constants
{
    public static class CacheKeys
    {
        public static string GetEmailConfirmationKey(string id)
        {
            return $"emailconfirmationkeyid:{id}";
        }
        public static string GetEmailConfirmationCode(string id)
        {
            return $"emailconfirmationcodeid:{id}:";
        }
        public static string GetResetToken(string id)
        {
            return $"resettokenid:{id}:";
        }
    }
}
