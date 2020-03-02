using System;
using System.Transactions;
using Comm100.Domain.Uow;

namespace Comm100.Framework.Infrastructure
{
    public class DisabledUnitOfWorkManager : IUnitOfWorkManager
    {
        public IUnitOfWork Current => Instance;

        public IUnitOfWork Begin()
        {
            return Current;
        }

        public IUnitOfWork Begin(IsolationLevel isolationLevel)
        {
            return Current;
        }

        public static IUnitOfWork Instance = new DisabledUnitOfWork();
    }

    public class DisabledUnitOfWork : IUnitOfWork
    {
        public TransactionOptions TransactionOptions => EmptyOptions;

        public event EventHandler Disposed;

        public void Complete()
        {
        }

        public void Dispose()
        {
        }

        public static TransactionOptions EmptyOptions = new TransactionOptions { };
    }
}
