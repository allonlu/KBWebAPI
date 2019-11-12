using System;
namespace Comm100.Framework.AuditLog
{
    public class AuditLogService : IAuditLogService
    {
        public AuditLogService()
        {
        }

        public void Add(Guid agentId, string app, string ip, string source, string action, object[] details)
        {
            throw new NotImplementedException();
        }
    }
}
