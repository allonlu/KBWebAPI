//-----------------------------------------------------------------------
// <copyright file="IUnitOfWorkManager.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Domain.Uow
{
    using System.Transactions;

    public interface IUnitOfWorkManager
    {
        IUnitOfWork Begin();
        IUnitOfWork Begin(IsolationLevel isolationLevel);
        IUnitOfWork Current { get; }
    }
}
