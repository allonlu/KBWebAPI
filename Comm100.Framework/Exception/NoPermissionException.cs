using System;
namespace Comm100.Framework.Exception
{
    public class NoPermissionException : BaseException
    {
        private const string Description = "You have no '{0}' permission.";
        public NoPermissionException(string permission)
            : base(403000, string.Format(Description, permission))
        {
        }
    }
}
