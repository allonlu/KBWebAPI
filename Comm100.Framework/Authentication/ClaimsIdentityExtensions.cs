namespace Comm100.Framework.Authentication
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Principal;

    public static class ClaimsIdentityExtensions
    {
        public static int? GetUserId(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            if (claimsIdentity != null && claimsIdentity.Claims != null)
            {
                var userIdOrNull = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdOrNull == null || string.IsNullOrWhiteSpace(userIdOrNull.Value))
                {
                    return null;
                }

                return Convert.ToInt32(userIdOrNull.Value);
            }

            return null;
        }
        public static int? GetSiteId(this ClaimsIdentity identity)
        {
            var userIdOrNull = identity.Claims.FirstOrDefault(c => c.Type == Comm100ClaimTypes.SideId);
            if (userIdOrNull == null || string.IsNullOrWhiteSpace(userIdOrNull.Value))
            {
                return null;
            }

            return Convert.ToInt32(userIdOrNull.Value);

        }
    }
}
