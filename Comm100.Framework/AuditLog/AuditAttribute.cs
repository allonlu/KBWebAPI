using System;
namespace Comm100.Framework.AuditLog
{
    public class AuditAttribute : Attribute
    {
        public string Action { get; private set; }

        public AuditAttribute(string action)
        {
            this.Action = action;
        }
    }
}
