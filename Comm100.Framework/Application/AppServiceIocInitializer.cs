using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Comm100.Application.Interceptors;
using Comm100.Application.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Comm100.Application
{
    public static class AppServiceIocInitializer
    {
        public static void AppServiceRegister(this IKernel kernel,Assembly assembly)
        {
            kernel.Register(
             Component.For<AppServiceInterceptor>()
                     .ImplementedBy<AppServiceInterceptor>()
                     .LifestyleTransient(),

             Classes.FromAssembly(assembly)
             .IncludeNonPublicTypes()
             .BasedOn<IAppService>()
             .Configure(configurer =>
             {
                 configurer.Named(configurer.Implementation.Name);
                 ///注册AOP拦截器
                 _ = configurer.Interceptors(InterceptorReference.ForType<AppServiceInterceptor>()).Anywhere;
             })
              .WithService.Self()
              .WithService.DefaultInterfaces()
              .LifestyleTransient()
             );
        }
    }
}
