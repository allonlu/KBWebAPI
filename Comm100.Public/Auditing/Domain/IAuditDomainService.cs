//-----------------------------------------------------------------------
// <copyright file="IAuditLogService.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Public.Audit.Domain
{
    using System;

    public interface IAuditDomainService
    {
        void Add(Guid agentId, string app, string ip, string source, string action, object[] details);
    }
}
