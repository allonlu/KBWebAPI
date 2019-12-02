using System;
using System.Collections.Generic;
using Comm100.Framework.Authentication;
using Comm100.Framework.Authentication.Session;
using Comm100.Framework.Authorization;
using Comm100.Framework.Exception;
using Comm100.Public.Authorization.RolePermission;

namespace Comm100.Public.Authorization
{
    public class AuthorizationProvider : IAuthorizationProvider
    {
        private BaseRolePermission _permission;

        public AuthorizationProvider(ISession session)
        {
            if (session.Role == Role.SYSTEM)
            {
                this._permission = new FullPermission();
            } else if (session.Role == Role.APPLICATION) {
                this._permission = new ApplicationRolePermission(session.Application);
            } else if (session.Role == Role.AGENT)
            {
                this._permission = new AgentPermission(session.SiteId.GetValueOrDefault(), session.UserId.GetValueOrDefault());
            } else if (session.Role == Role.ANONYMOUS)
            {
                this._permission = new AnonymousPermission();
            } else if (session.Role == Role.PARTNER)
            {
                this._permission = new PartnerRolePermission(session.UserId.GetValueOrDefault());
            } else
            {
                this._permission = new NoPermission();
            }
        }

        public bool IsGranted(string application, string[] permissions)
        {
            foreach(string permission in permissions)
            {
                if (!this._permission.HavePermission(application, permission))
                {
                    throw new NoPermissionException(permission);
                }
            }

            return true;
        }
    }
}
