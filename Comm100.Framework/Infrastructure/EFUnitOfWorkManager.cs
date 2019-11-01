using Castle.DynamicProxy;
using Castle.Windsor;
using Castle.Windsor.Proxy;
using Comm100.Domain.Uow;
using Comm100.Framework.Tenants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Comm100.Framework.Infrastructure
{
    public class EFUnitOfWorkManager : IUnitOfWorkManager
    {
        private DbContext _dbContext;
        private Tenant _tenant;
        private IUnitOfWork _outerUow;
        public EFUnitOfWorkManager(DbContext dbContext, ITenantProvider tenantProvider)
        {
            this._dbContext = dbContext;
            this._tenant = tenantProvider.GetTenant();
        }

        public IUnitOfWork Current =>_outerUow;

        public IUnitOfWork Begin()
        {
            return Begin(IsolationLevel.ReadCommitted);
        }

        public IUnitOfWork Begin(IsolationLevel isolationLevel)
        {
            ///已经存在外部工作单元,则返回一个InnerUnitOfWork
            if (_outerUow != null)
                return new InnerUnitOfWork();
            var option = new TransactionOptions
            {
                IsolationLevel = isolationLevel
            };

            var uow = new EFUnitOfWork(_dbContext, option, _tenant);

            uow.Disposed += (sender, e) =>
            {
                _outerUow = null;
            };

            _outerUow = uow;

            return _outerUow;
        }
    }
}
