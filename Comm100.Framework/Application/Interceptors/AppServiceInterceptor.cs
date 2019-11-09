using Castle.DynamicProxy;
using Comm100.Domain.Ioc;
using Comm100.Domain.Uow;
using Comm100.Extension;
using Comm100.Framework.AuditLog;
using Comm100.Framework.Extensions;
using Comm100.Framework.Logging;
using Comm100.Runtime;
using Comm100.Runtime.Exception;
using Comm100.Runtime.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace Comm100.Framework.Application.Interceptors
{

    public class AppServiceInterceptor : IInterceptor
    {
        [Mandatory]
        public ISession Session { get; set; }

        [Mandatory]
        public IPermissionChecker PermissionChecker { get; set; }

        [Mandatory]
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
            var action = invocation.GetAuditAction();
            if (action != null)
            {
                AuditLogService.Add(Session.GetApplication(), "", Session.GetAgentId() ?? Guid.Empty, action, invocation.Arguments);
            }
        }


        private void CheckPermission(IInvocation invocation)
        {
            var attrs = invocation.GetAttributes<PermissionAttribute>();
            if (attrs.Length != 0)  // permission defined
            {
                var permission = attrs[0].Name;

                if (!PermissionChecker.IsGranted(Session, permission))
                {
                    Logger.Info($"SiteId:{Session.GetSiteId()},AgentId:{Session.GetAgentId()},Type:PermissionCheckFail,Permission:{permission} ");
                    throw new AuthorizationException();
                }
            }
        }
    }
}
