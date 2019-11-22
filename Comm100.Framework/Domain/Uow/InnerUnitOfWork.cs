//-----------------------------------------------------------------------
// <copyright file="InnerUnitOfWork.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Domain.Uow
{
    using System;
    using System.Transactions;

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
    }
}
