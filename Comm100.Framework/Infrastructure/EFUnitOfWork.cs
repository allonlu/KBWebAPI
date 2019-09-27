using Comm100.Domain.Entity;
using Comm100.Domain.Uow;
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
        private int _siteId;

        public TransactionOptions TransactionOptions => options;

        public EFUnitOfWork(DbContext dbContext, TransactionOptions options)
        {
            
           
            _transaction = dbContext.Database.BeginTransaction();
            _isCommitted = false;
            _dbContext = dbContext;
            this.options = options;
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

        public void SetSiteId(int siteId)
        {
            _siteId = siteId;
            var databaseName = GetDatabase(siteId);

            ChangeDatabase(databaseName);
            ChangeTableName(siteId);
        }

        private void ChangeTableName(int siteId)
        {
            
            foreach (IEntityType entityType in _dbContext.Model.GetEntityTypes())
            {
                ///如果entity继承IBelongToSite接口，就会更换表名
                if (entityType.ClrType.GetCustomAttributes(true).OfType<TableBySiteAttribute>().Any())
                {
                    if (entityType.Relational() is RelationalEntityTypeAnnotations relational)
                    {
                       relational.TableName = CreateTableName(relational, siteId);
                    }
                }
            }
        }
        private string  CreateTableName(RelationalEntityTypeAnnotations relational, int siteId)
        {
            return relational.TableName + siteId;
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
                var connectionString = Regex.Replace(connection.ConnectionString.Replace(" ", ""), @"(?<=[Dd]atabase=)\w+(?=;)", databaseName, RegexOptions.Singleline);
                connection.ConnectionString = connectionString;
            }
        }

        private string GetDatabase(int siteId)
        {
            return "KB";

        }


        public int GetSiteId()
        {
            return _siteId;
        }
    }
}
