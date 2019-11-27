//-----------------------------------------------------------------------
// <copyright file="AppServiceInterceptor.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Application.Interceptors
{
    using Castle.DynamicProxy;
    using Comm100.Domain.Uow;
    using Comm100.Framework.AuditLog;
    using Comm100.Framework.Authentication.Session;
    using Comm100.Framework.Authorization;
    using Comm100.Framework.Exception;
    using Comm100.Framework.Extension;
    using Comm100.Framework.Logging;
    using System;

    public class AppServiceInterceptor : IInterceptor
    {
        public ISession Session { get; set; }

        public IPermissionChecker PermissionChecker { get; set; }

        public ILogger Logger { get; set; }

        public IAuditLogService AuditLogService { get; set; }

        private IUnitOfWorkManager _unitOfWorkMananger;
        public AppServiceInterceptor(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkMananger = unitOfWorkManager;
            Logger = NullLogger.Instance;
            PermissionChecker = NullPermissionChecker.Instance;
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
                AuditLogService.Add(Session.GetAgentId() ?? Guid.Empty, Session.GetApplication(), Session.GetIP(),
                    audit.Source,  audit.Action.ToString(), invocation.Arguments);
            }
        }


        private void CheckPermission(IInvocation invocation)
        {
            var attrs = invocation.GetAttributes<AuthorizationAttribute>();
            if (attrs.Length == 0)  // permission defined
            {
                return;
            }
            var source = attrs[0].Source;
            var type = attrs[0].Type;

            if (!PermissionChecker.IsGranted(Session, source, type))
            {
                Logger.Info($"SiteId:{Session.GetSiteId()},AgentId:{Session.GetAgentId()},Type:PermissionCheckFail,Permission:{source}:{type} ");
                throw new AuthorizationException();
            }
        }
    }
}
