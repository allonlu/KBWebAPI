using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace KB.Infrastructure
{
    public class TableIsolationCommandInterceptor : DbCommandInterceptor
    {
        private ITableIsolationResolver _resolver;
        public TableIsolationCommandInterceptor(ITableIsolationResolver resolver)
        {
            this._resolver = resolver;
        }
        
        public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            command.CommandText = _resolver.ReplaceTableName(command.CommandText);
            return base.NonQueryExecuting(command, eventData, result);
        }

        public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            command.CommandText = _resolver.ReplaceTableName(command.CommandText);
            return base.ScalarExecuting(command, eventData, result);
        }

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            command.CommandText = _resolver.ReplaceTableName(command.CommandText);
            return base.ReaderExecuting(command, eventData, result);
        }
    }
}
