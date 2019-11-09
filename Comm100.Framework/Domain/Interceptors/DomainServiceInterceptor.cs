using Castle.DynamicProxy;
using Comm100.Domain.Uow;
using Comm100.Framework.Extensions;
using Comm100.Runtime.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comm100.Domain.Interceptors
{
    public class DomainServiceInterceptor : IInterceptor
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public DomainServiceInterceptor(IUnitOfWorkManager unitOfWorkManager)
        {
            this._unitOfWorkManager = unitOfWorkManager;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodIsolationLevel = (int)invocation.GetIsolationLevel();
            var currentIsolationLevel = (int)this._unitOfWorkManager.Current.TransactionOptions.IsolationLevel;
            if (methodIsolationLevel < currentIsolationLevel)
                throw new IsolationLevelException();

            invocation.Proceed();
        }
    }
}
