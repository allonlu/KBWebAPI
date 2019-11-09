using System;
namespace Comm100.Framework.AuditLog
{
    public interface IAuditLogService
    {
        void Add(string app, string module, Guid agentId, string action, object[] details);
    }
}
