using System;
using Comm100.Framework.Authorization;

namespace Comm100.Public.Authorization.RolePermission
{
    public class AgentPermission : BaseRolePermission
    {
        public AgentPermission(int siteId, Guid agentId)
        {
            // read permission from data base
        }

        internal override bool HavePermission(string application, string permission)
        {
            return true;
        }
    }
}
