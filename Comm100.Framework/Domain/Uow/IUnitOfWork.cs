using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Comm100.Domain.Uow
{
    public interface IUnitOfWork: IDisposable
    {
        event EventHandler Disposed;
        void SetSiteId(int siteId);
        int GetSiteId();
        void Complete();
        TransactionOptions TransactionOptions { get; }
    }
}
