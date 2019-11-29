//-----------------------------------------------------------------------
// <copyright file="AuditLogService.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Public.Audit.Domain
{
    using System;
    using Comm100.Framework.Domain.Repository;

    public class AuditDomainService : IAuditDomainService
    {
        private IRepository<Guid, AuditLog> _repository;

        public AuditDomainService(IRepository<Guid, AuditLog> repository)
        {
            this._repository = repository;
        }

        public void Add(Guid agentId, string app, string ip, string source, string action, object[] details)
        {
            AuditLog log = new AuditLog();
            _repository.Create(log);
        }
    }
}
