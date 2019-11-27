using System;
using System.Collections.Generic;
using Comm100.Framework.Domain.Repository;

namespace Comm100.Public.Account.Domain
{
    public class AgentDomainService : IAgentDomainService
    {
        private IRepository<Guid, Agent> _repository;

        public AgentDomainService(IRepository<Guid, Agent> repository)
        {
            this._repository = repository;
        }

        public Agent Get(Guid id)
        {
            return this._repository.Get(id);
        }

        public IEnumerable<Agent> List()
        {
            return this._repository.ListAll();
        }
    }
}
