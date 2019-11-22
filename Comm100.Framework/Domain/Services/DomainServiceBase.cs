//-----------------------------------------------------------------------
// <copyright file="DomainServiceBase.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Domain.Services
{
    using Comm100.Framework.Logging;

    public abstract class DomainServiceBase : IDomainService
    {
        public DomainServiceBase()
        {
            this.Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }
    }
}
