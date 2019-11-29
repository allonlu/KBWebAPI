using System;
using Comm100.Framework.Auditing;
using Comm100.Public.Audit.Domain;

namespace Comm100.Public.Auditing
{
    public class AuditLogger : IAuditLogger
    {
        public AuditLogger(IAuditDomainService domainService)
        {
        }

        public void Add(Guid agentId, string app, string ip, string source, string action, object[] details)
        {
            // TODO
            // call domain service to insert data to db
        }
    }
}
