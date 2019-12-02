using System;
using System.Linq;
using System.Security.Claims;

namespace Comm100.Framework.Authentication
{
    public static class ClaimsIdentityExtension
    {
        private static string GetClaimValue(this ClaimsIdentity identity, string type)
        {
            if (identity != null && identity.Claims != null)
            {
                var claim = identity.Claims.FirstOrDefault(claim => claim.Type == type);

                if (claim != null)
                {
                    return claim.Value;
                }
            }

            return null;
        }

        public static Guid? GetUserId(this ClaimsIdentity identity)
        {
            string userId = identity.GetClaimValue(ClaimTypes.NameIdentifier);
            
            if (!string.IsNullOrEmpty(userId))
            {
                return new Guid(userId);
            }

            return null;
        }

        public static int? GetSiteId(this ClaimsIdentity identity)
        {
            var siteId = identity.GetClaimValue(Comm100ClaimTypes.SITE_ID);

            if (!string.IsNullOrEmpty(siteId))
            { 
                return Convert.ToInt32(siteId);
            }

            return null;
        }

        public static string GetApplication(this ClaimsIdentity identity)
        {
            return identity.GetClaimValue(Comm100ClaimTypes.APPLICATION);
        }

        public static Role GetRole(this ClaimsIdentity identity)
        {
            var role = identity.GetClaimValue(ClaimTypes.Role);

            return Enum.Parse<Role>(role);
        }
    }
}
