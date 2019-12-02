using System;
namespace Comm100.Public.Authorization.RolePermission
{
    public abstract class BaseRolePermission
    {
        internal abstract bool HavePermission(string application, string permission);
    }
}
