using System;
namespace Comm100.Framework.Auditing
{ 
    public interface IAuditLogger
    {
        void Add(Guid agentId, string app, string ip, string source, string action, object[] details);
    }
}
