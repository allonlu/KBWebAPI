

namespace Comm100.Framework.Infrastructure
{
    using System;
    using System.Data;
    using System.Transactions;
    using Comm100.Domain.Uow;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    

    public class EFUnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction ;
        private BaseDBContext _dbContext;
        private readonly TransactionOptions options;
        private bool _isCommitted;

        public TransactionOptions TransactionOptions => options;

        public EFUnitOfWork(BaseDBContext dbContext, TransactionOptions options)
        {
            _transaction = dbContext.Database.BeginTransaction();
            _isCommitted = false;
            _dbContext = dbContext;
            this.options = options;

            var databaseName = dbContext.Tenant.DatabaseName;

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
