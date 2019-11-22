//-----------------------------------------------------------------------
// <copyright file="TransactionAttribute.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Infrastructure
{
    using System;
    using System.Transactions;

    public class TransactionAttribute : Attribute
    {
        public IsolationLevel IsolationLevel { get; private set; }

        public TransactionAttribute(IsolationLevel isolationLevel)
        {
            this.IsolationLevel = isolationLevel;
        }
        public TransactionAttribute():this(IsolationLevel.ReadCommitted){}
    }
}
