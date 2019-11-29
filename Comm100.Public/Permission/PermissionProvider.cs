using System;
using Comm100.Framework.Authentication;
using Comm100.Framework.Authentication.Session;
using Comm100.Framework.Authorization;

namespace Comm100.Public.Permission
{
    public class PermissionProvider : IPermissionProvider
    {
        private BasePermission _permission;
        public PermissionProvider(ISession session)
        {
            if (session.Role == Role.SYSTEM)
            {
                this._permission = new FullPermission();
            } else if (session.Role == Role.APPLICATION) {
                // TODO
                // create permission base on application scope
            } else if (session.Role == Role.AGENT)
            {
                this._permission = new AgentPermission(session.SiteId.GetValueOrDefault(), session.UserId.GetValueOrDefault());
            } else if (session.Role == Role.ANONYMOUS)
            {
                this._permission = new AnonymousPermission();
            } else if (session.Role == Role.PARTNER)
            {
                //TODO
                // create permission base on partner
            } else
            {
                this._permission = new NoPermission();
            }
            
        }

        public bool Read(string source)
        {
            return _permission.HavePermissionRead(source);
        }

        public bool Write(string source)
        {
            return _permission.HavePermissionWrite(source);
        }
    }
}
