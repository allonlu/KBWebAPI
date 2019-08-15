using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Comm100.Domain.Uow
{
    public interface IUnitOfWorkManager
    {
        IUnitOfWork Begin();
        IUnitOfWork Begin(IsolationLevel isolationLevel);
        IUnitOfWork Current { get; }
    }
}
