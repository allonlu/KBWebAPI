using System;
namespace Comm100.Framework.AuditLog
{
    public interface IAuditLogService
    {
        void Add(Guid agentId, string app, string ip, string source, string action, object[] details);
    }
}
