using System;
using Comm100.Framework.Authorization;

namespace Comm100.Public.Authorization.RolePermission
{
    public class FullPermission : BaseRolePermission
    {
        internal override bool HavePermission(string application, string permission)
        {
            return true;
        }
    }
}
