//-----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Domain.Uow
{
    using System;
    using System.Transactions;

    public interface IUnitOfWork: IDisposable
    {
        event EventHandler Disposed;

        void Complete();

        TransactionOptions TransactionOptions { get; }
    }
}
