using System;
namespace Comm100.Framework.AuditLog
{
    public class AuditAttribute : Attribute
    {
        public string Source { get; private set; }

        public EnumAuditAction Action { get; private set; }

        public AuditAttribute(string source, EnumAuditAction action)
        {
            this.Source = source;
            this.Action = action;
        }
    }
}
