using Comm100.Domain.Entity;
using Comm100.Domain.Uow;
using Comm100.Framework.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace Comm100.Framework.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction ;
        private DbContext _dbContext;
        private readonly TransactionOptions options;
        private bool _isCommitted;

        public TransactionOptions TransactionOptions => options;

        public EFUnitOfWork(DbContext dbContext, TransactionOptions options, Tenant tenant)
        {
            _transaction = dbContext.Database.BeginTransaction();
            _isCommitted = false;
            _dbContext = dbContext;
            this.options = options;

            var databaseName = tenant.DatabaseName;

            ChangeDatabase(databaseName);
        }

        public event EventHandler Disposed;
        public void Complete()
        {
            _transaction.Commit();
            _isCommitted = true;
        }

        public void Dispose()
        {
            if (!_isCommitted)
                _transaction.Rollback();
            _transaction.Dispose();
            Disposed(this, null);
        }

        private void ChangeDatabase(string databaseName)
        {
            var connection = _dbContext.Database.GetDbConnection();
            if (connection.State.HasFlag(ConnectionState.Open))
            {
                connection.ChangeDatabase(databaseName);
            }
            else
            {
                connection.Open();
                connection.ChangeDatabase(databaseName);
            }
        }
    }
}
