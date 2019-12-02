using System.Reflection;
using Castle.Core;
using Comm100.Application.Services;
using Comm100.Framework.Application.Interceptors;
using Comm100.Framework.Authentication.Session;
using Comm100.Framework.Authorization;
using Comm100.Framework.AutoMapper;
using Comm100.Framework.Domain.Interceptors;
using Comm100.Framework.Domain.Services;
using Comm100.Framework.Extension;
using Comm100.Framework.Logging;

namespace Comm100.Framework.Module
{
    [DependsOn(typeof(AutoMapperModule))]
    public class BaseApplicationModule : AbstractModule
    {
        public override void Initialize()
        {
            this.Container.RegisterIfNot<ILogger, NLogger>();
            this.Container.RegisterIfNot<ISession, Session>(DependencyLifeStyle.Scoped);
            this.Container.RegisterIfNot<IAuthorizationProvider, AuthorizationProvider>(DependencyLifeStyle.Scoped);
            this.Container.RegisterIfNot<AppServiceInterceptor>(DependencyLifeStyle.Transient);
            this.Container.RegisterAssembly<IAppService>(Assembly.GetAssembly(this.GetType()), configurer => {
                _ = configurer.Named(configurer.Implementation.Name);
                //// register ioc interceptor
                _ = configurer.Interceptors(InterceptorReference.ForType<AppServiceInterceptor>()).Anywhere;
            });
        }
    }
}
