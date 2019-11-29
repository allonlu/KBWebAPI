using System;
using Comm100.Framework.Authorization;

namespace Comm100.Public.Permission
{
    public class AgentPermission : BasePermission
    {
        public AgentPermission(int siteId, Guid agentId)
        {
            // read permission from data base
        }

        internal override bool HavePermissionRead(string source)
        {
            return true;
        }

        internal override bool HavePermissionWrite(string source)
        {
            return true;
        }
    }
}
