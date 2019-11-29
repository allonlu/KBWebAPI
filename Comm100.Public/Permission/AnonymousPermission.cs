using System;
namespace Comm100.Public.Permission
{
    public class AnonymousPermission : BasePermission
    {
        public AnonymousPermission()
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
