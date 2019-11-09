using System;
namespace Comm100.Framework.AuditLog
{
    public class AuditLogService : IAuditLogService
    {
        public AuditLogService()
        {
        }

        public void Add(string app, string module, Guid agentId, string action, object[] details)
        {
            throw new NotImplementedException();
        }
    }
}
