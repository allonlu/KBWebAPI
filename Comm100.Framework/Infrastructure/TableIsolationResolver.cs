using System;
using Comm100.Framework.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Comm100.Framework.Infrastructure
{
    public class MultiTenantTableResolver : IMultiTenantTableResolver
    {
        private ITenantProvider _provider;
        
        public MultiTenantTableResolver(ITenantProvider provider)
        {
            this._provider = provider;
        }

        
    }
}
