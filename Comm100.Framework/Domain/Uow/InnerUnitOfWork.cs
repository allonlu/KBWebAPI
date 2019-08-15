using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Comm100.Domain.Uow
{
    public class InnerUnitOfWork : IUnitOfWork
    {

        public int _siteId;

        public TransactionOptions TransactionOptions => throw new NotImplementedException();

        public event EventHandler Disposed;

        public void Complete()
        {
            
        }

        public void Dispose()
        {
          
        }

        public int GetSiteId()
        {
            return _siteId;
        }

        public void SetSiteId(int siteId)
        {
            _siteId = siteId;
        }
    }
}
