//-----------------------------------------------------------------------
// <copyright file="AppServiceIocInitializer.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Application
{
    using Castle.Core;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Comm100.Application.Services;
    using Comm100.Framework.Application.Interceptors;
    using System.Reflection;

    public static class AppServiceIocInitializer
    {
        public static void AppServiceRegister(this IKernel kernel, Assembly assembly) => _ = kernel.Register(
                Component.For<AppServiceInterceptor>()
                     .ImplementedBy<AppServiceInterceptor>()
                     .LifestyleTransient(),

                Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<IAppService>()
                    .Configure(configurer =>
                         {
                             _ = configurer.Named(configurer.Implementation.Name);
                             //// register ioc interceptor
                             _ = configurer.Interceptors(InterceptorReference.ForType<AppServiceInterceptor>()).Anywhere;
                         })
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient());
    }
}