using System;
namespace Comm100.Framework.AuditLog
{
    public class AuditAttribute : Attribute
    {
        public string Source { get; private set; }

        public AuditAction Action { get; private set; }

        public AuditAttribute(string source, AuditAction action)
        {
            this.Source = source;
            this.Action = action;
        }
    }
}
