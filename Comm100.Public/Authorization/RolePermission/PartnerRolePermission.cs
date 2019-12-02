using System;
namespace Comm100.Public.Authorization.RolePermission
{
    public class PartnerRolePermission : BaseRolePermission
    {
        public PartnerRolePermission(Guid partnerId)
        {

        }

        internal override bool HavePermission(string application, string permission)
        {
            throw new NotImplementedException();
        }
    }
}
