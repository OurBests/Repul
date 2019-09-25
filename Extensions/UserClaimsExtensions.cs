using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace web.Extensions
{
    public static class UserClaimsExtensions
    {
        public static string GetClaimValue(this IEnumerable<Claim> claims, string key)
        {
            return claims.FirstOrDefault(x => x.Type == key)?.Value;
        }
        public static string GetUserId(this IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
