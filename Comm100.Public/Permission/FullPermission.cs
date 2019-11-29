using System;
using Comm100.Framework.Authorization;

namespace Comm100.Public.Permission
{
    public class FullPermission : BasePermission
    {
        internal override bool HavePermissionRead(string source)
        {
            return true;
        }

        internal override bool HavePermissionWrite(string source)
        {
            return false;
        }
    }
}
