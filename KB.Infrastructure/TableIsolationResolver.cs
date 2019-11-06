using System;
using Comm100.Framework.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KB.Infrastructure
{
    public class TableIsolationResolver : ITableIsolationResolver
    {
        private ITenantProvider _provider;
        
        public TableIsolationResolver(ITenantProvider provider)
        {
            this._provider = provider;
        }

        public string ReplaceTableName(string commandText)
        {
            int tenantId = _provider.GetTenant().Id;
            return commandText.Replace("{#TENANTID}", tenantId.ToString());
        }
    }
}
