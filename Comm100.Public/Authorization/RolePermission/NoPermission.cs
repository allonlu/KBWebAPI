using System;
namespace Comm100.Public.Authorization.RolePermission
{
    public class NoPermission : BaseRolePermission
    {
        internal override bool HavePermission(string application, string permission)
        {
            return false;
        }
    }
}
