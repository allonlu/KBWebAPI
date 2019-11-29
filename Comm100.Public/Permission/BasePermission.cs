using System;
namespace Comm100.Public.Permission
{
    public abstract class BasePermission
    {
        internal abstract bool HavePermissionRead(string source);
        internal abstract bool HavePermissionWrite(string source);
    }
}
