using System;
using System.Security.Principal;

namespace Comm100.Framework.Authentication
{
    public class UserIdentity : IIdentity
    {
        public Role Role { get; private set; }

        public string Application { get; private set; }

        public int? SiteId { get; set; }

        public Guid? UserId { get; private set; }

        public UserIdentity(Role role, string application, int? siteId, Guid? userId) {
            this.Role = role;
            this.Application = application;
            this.SiteId = siteId;
            this.UserId = userId;
        }
        
        public string AuthenticationType => "jwt";

        public bool IsAuthenticated => true;

        public string Name => "";
    }
}
