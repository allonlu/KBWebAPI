//-----------------------------------------------------------------------
// <copyright file="AppServiceInterceptor.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Application.Interceptors
{
    using Castle.DynamicProxy;
    using Comm100.Domain.Uow;
    using Comm100.Framework.Auditing;
    using Comm100.Framework.Authentication.Session;
    using Comm100.Framework.Authorization;
    using Comm100.Framework.Exceptions;
    using Comm100.Framework.Extension;
    using Comm100.Framework.Logging;
    using System;
    using System.Linq;

    public class AppServiceInterceptor : IInterceptor
    {
        public ISession Session { get; set; }

        public IAuthorizationProvider AuthorizationProvider { get; set; }

        public ILogger Logger { get; set; }

        public IAuditLogger AuditLogger { get; set; }

        private IUnitOfWorkManager _unitOfWorkMananger;

        private string Application { get; set; }

        public AppServiceInterceptor(IUnitOfWorkManager unitOfWorkManager, IAuthorizationProvider provider)
        {
            _unitOfWorkMananger = unitOfWorkManager;
            this.AuthorizationProvider = provider;
            Logger = NullLogger.Instance;
            Session = NullSession.Instance;
        }

        void IInterceptor.Intercept(IInvocation invocation)
        {
            CheckPermission(invocation);

            using (var uow = _unitOfWorkMananger.Begin(invocation.GetIsolationLevel()))
            {
                invocation.Proceed();

                Audit(invocation);

                uow.Complete();
            }
        }

        private void Audit(IInvocation invocation)
        {
            AuditAttribute audit = invocation.GetAudit();
            if (audit != null)
            {
                AuditLogger.Add(Session.UserId ?? Guid.Empty, Session.Application, Session.IP,
                    audit.Source,  audit.Action.ToString(), invocation.Arguments);
            }
        }


        private void CheckPermission(IInvocation invocation)
        {
            var attrs = invocation.GetAttributes<AuthorizationAttribute>();
            if (attrs.Length == 0)  // permission undefined
            {
                return;
            }

            var permissions = attrs[0].Permissions;

            if (!AuthorizationProvider.IsGranted(this.Application, permissions))
            {
                throw new AuthorizationException();
            }
        }
    }
}
