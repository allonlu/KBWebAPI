using Comm100.Domain.Ioc;
using Comm100.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Domain.Services
{
    public abstract class DomainServiceBase:IDomainService
    {
        public DomainServiceBase()
        {
            this.Logger = NullLogger.Instance;
        }

        [Mandatory]
        public ILogger Logger { get; set; }
    }
}
