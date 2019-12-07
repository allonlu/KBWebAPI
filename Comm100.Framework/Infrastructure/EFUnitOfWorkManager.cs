namespace Comm100.Framework.Infrastructure
{
    using Comm100.Domain.Uow;
    using System.Transactions;

    public class EFUnitOfWorkManager : IUnitOfWorkManager
    {
        private BaseDBContext _dbContext;
        private IUnitOfWork _outerUow;

        public EFUnitOfWorkManager(BaseDBContext dbContext)
        {
            this._dbContext = dbContext;
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

            var uow = new EFUnitOfWork(_dbContext, option);

            uow.Disposed += (sender, e) =>
            {
                _outerUow = null;
            };

            _outerUow = uow;

            return _outerUow;
        }
    }
}
