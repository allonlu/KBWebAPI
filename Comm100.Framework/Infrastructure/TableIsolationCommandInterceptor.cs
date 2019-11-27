//-----------------------------------------------------------------------
// <copyright file="TableIsolationCommandInterceptor.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Infrastructure
{
    using System.Data.Common;
    using Comm100.Framework.Tenants;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Comm100.Framework.Constants;

    public class MultiTenantTableCommandInterceptor : DbCommandInterceptor
    {
        private readonly Tenant _tenant;

        public MultiTenantTableCommandInterceptor(Tenant tenant)
        {
            this._tenant = tenant;
        }

        private string ReplaceTenantId(string commandText)
        {
            int tenantId = _tenant.Id;

            return commandText.Replace(DBConstants.MULTI_TENANT_TABLE_PLACEHOLDER, tenantId.ToString());
        }

        public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            command.CommandText = ReplaceTenantId(command.CommandText);
            return base.NonQueryExecuting(command, eventData, result);
        }

        public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            command.CommandText = ReplaceTenantId(command.CommandText);
            return base.ScalarExecuting(command, eventData, result);
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            command.CommandText = ReplaceTenantId(command.CommandText);
            return base.ReaderExecuting(command, eventData, result);
        }
    }
}
