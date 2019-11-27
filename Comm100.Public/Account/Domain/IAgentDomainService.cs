using System;
using System.Collections.Generic;
using Comm100.Framework.Domain.Services;

namespace Comm100.Public.Account.Domain
{
    public interface IAgentDomainService : IDomainService
    {
        Agent Get(Guid id);
        IEnumerable<Agent> List();
    }
}
