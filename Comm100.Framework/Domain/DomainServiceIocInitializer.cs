//-----------------------------------------------------------------------
// <copyright file="DomainServiceIocInitializer.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Domain
{
    using Castle.Core;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Comm100.Domain.Interceptors;
    using Comm100.Domain.Services;
    using System.Reflection;

    public static class DomainServiceIocInitializer
    {
        public static void DomainServiceRegister(this IKernel kernel, Assembly assembly)
        {
            kernel.Register(
                Component.For<DomainServiceInterceptor>()
                        .ImplementedBy<DomainServiceInterceptor>()
                        .LifestyleTransient(),

                Classes.FromAssembly(assembly)
                        .IncludeNonPublicTypes()
                        .BasedOn<IDomainService>()
                        .Configure(configurer =>
                        {
                            configurer.Named(configurer.Implementation.Name);
                            ///注册AOP拦截器
                            _ = configurer.Interceptors(InterceptorReference.ForType<DomainServiceInterceptor>()).Anywhere;
                        })
                        .WithService.Self()
                        .WithService.DefaultInterfaces()
                        .LifestyleTransient()
            );
        }
    }
}
