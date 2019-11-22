//-----------------------------------------------------------------------
// <copyright file="DomainServiceInterceptor.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Domain.Interceptors
{
    using Castle.DynamicProxy;
    using Comm100.Domain.Uow;
    using Comm100.Framework.Exception;
    using Comm100.Framework.Extension;

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
