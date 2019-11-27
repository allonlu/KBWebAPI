using System;
using System.Reflection;
using Castle.Core;
using Comm100.Framework.Domain.Interceptors;
using Comm100.Framework.Domain.Services;
using Comm100.Framework.Extension;

namespace Comm100.Framework.Module
{
    public class BaseDomainModule : AbstractModule
    {
        public override void Initialize()
        {
            this.Container.RegisterIfNot<DomainServiceInterceptor>(DependencyLifeStyle.Transient);
            this.Container.RegisterAssembly<IDomainService>(Assembly.GetAssembly(this.GetType()), configurer =>
            {
                _ = configurer.Named(configurer.Implementation.Name);
                _ = configurer.Interceptors(InterceptorReference.ForType<DomainServiceInterceptor>()).Anywhere;
            });
        }
    }
}
