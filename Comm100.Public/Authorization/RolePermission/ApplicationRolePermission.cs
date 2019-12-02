using System;
namespace Comm100.Public.Authorization.RolePermission
{
    public class ApplicationRolePermission : BaseRolePermission
    {
        public ApplicationRolePermission(string application)
        {

        }

        internal override bool HavePermission(string application, string permission)
        {
            return false;
        }
    }
}
