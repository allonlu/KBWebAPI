using Castle.DynamicProxy;
using Comm100.Domain.Ioc;
using Comm100.Domain.Uow;
using Comm100.Extension;
using Comm100.Runtime;
using Comm100.Runtime.Exception;
using Comm100.Runtime.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;

namespace Comm100.Application.Interceptors
{

    public class AppServiceInterceptor : IInterceptor
    {
        [Mandatory]
        public ISession Session { get; set; }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        [Mandatory]
        public IPermissionChecker PermissionChecker { get; set; }
        /// <summary>
        /// IOC容器注入
        /// </summary>
        /// 
        [Mandatory]
        public ILogger Logger { get; set; }

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
            var method = invocation.GetMethod();

            CheckPermission(method);

            using (var uow = _unitOfWorkMananger.Begin(method.GetIsolationLevel()))
            {

                //uow.SetSiteId(Session.GetSiteId());
                invocation.Proceed();
                uow.Complete();
            }
        }


        private void CheckPermission(MethodInfo method)
        {
            var attrs = method.GetCustomAttributes(true).OfType<PermissionAttribute>().ToArray();
            if (attrs.Length == 0)
            {
                throw new AuthorizationException();
            }
            var permissionName = attrs[0].Name;
            if (!PermissionChecker.IsGranted(Session.GetAgentId(), permissionName))
            {
                Logger.Info($"SiteId:{Session.GetSiteId()},AgentId:{Session.GetAgentId()},Type:PermissionCheckFail,Permission:{permissionName} ");
                throw new AuthorizationException();
            }
            Logger.Info($"SiteId:{Session.GetSiteId()},AgentId:{Session.GetAgentId()},Type:PermissionCheckSuccess,Permission:{permissionName} ");
        }
    }
}
