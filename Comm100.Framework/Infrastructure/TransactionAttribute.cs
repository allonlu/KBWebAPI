using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Comm100.Runtime.Transactions
{
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
