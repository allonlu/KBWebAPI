using System;
namespace Comm100.Public.Permission
{
    public class NoPermission : BasePermission
    {
        public NoPermission()
        {
        }

        internal override bool HavePermissionRead(string source)
        {
            return false;
        }

        internal override bool HavePermissionWrite(string source)
        {
            return false;
        }
    }
}
