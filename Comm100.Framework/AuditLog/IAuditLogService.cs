//-----------------------------------------------------------------------
// <copyright file="IAuditLogService.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.AuditLog
{
    using System;

    public interface IAuditLogService
    {
        void Add(Guid agentId, string app, string ip, string source, string action, object[] details);
    }
}
