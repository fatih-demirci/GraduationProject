using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            List<string>? result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }

        public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return Convert.ToInt64(claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
        }
    }
}
