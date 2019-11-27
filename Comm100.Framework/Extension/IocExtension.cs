using System;
using System.Reflection;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Comm100.Application.Services;
using Comm100.Framework.Application.Interceptors;
using Comm100.Framework.Authentication.Session;
using Comm100.Framework.Authorization;
using Comm100.Framework.Domain.Interceptors;
using Comm100.Framework.Domain.Services;
using Comm100.Framework.Logging;
using Comm100.Framework.Module;

namespace Comm100.Framework.Extension
{
    public static class IocExtension
    {
        public static bool IsRegistered<TType>(this IWindsorContainer container)
        {
            return container.Kernel.HasComponent(typeof(TType));
        }

        public static bool IsRegistered(this IWindsorContainer container, Type type)
        {
            return container.Kernel.HasComponent(type);
        }

        

        public static void Register<TType, TImpl>(this IWindsorContainer container, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType
        {
            container.Register(ApplyLifestyle(Component.For<TType, TImpl>().ImplementedBy<TImpl>(), lifeStyle));
        }

        public static void Register(this IWindsorContainer container, Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            container.Register(ApplyLifestyle(Component.For(type).ImplementedBy(impl), lifeStyle));
        }

        public static void Register<T>(this IWindsorContainer container, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class
        {
            container.Register(ApplyLifestyle(Component.For<T>().ImplementedBy<T>(), lifeStyle));
        }

        public static void Register(this IWindsorContainer container, Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            container.Register(ApplyLifestyle(Component.For(type).ImplementedBy(type), lifeStyle));
        }

        public static bool RegisterIfNot<T>(this IWindsorContainer container, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class
        {
            if (container.IsRegistered<T>())
            {
                return false;
            }

            container.Register<T>(lifeStyle);

            return true;
        }

        public static bool RegisterIfNot(this IWindsorContainer container, Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            if (container.IsRegistered(type))
            {
                return false;
            }

            container.Register(type, lifeStyle);
            return true;
        }

        public static bool RegisterIfNot<TType, TImpl>(this IWindsorContainer container, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType
        {
            if (container.IsRegistered<TType>())
            {
                return false;
            }

            container.Register<TType, TImpl>(lifeStyle);

            return true;
        }

        private static ComponentRegistration<T> ApplyLifestyle<T>(ComponentRegistration<T> registration, DependencyLifeStyle lifeStyle)
            where T : class
        {
            switch (lifeStyle){
                case DependencyLifeStyle.Transient:
                    return registration.LifestyleTransient();
                case DependencyLifeStyle.Singleton:
                    return registration.LifestyleSingleton();
                case DependencyLifeStyle.Scoped:
                    return registration.LifestyleScoped();
                default:
                    return registration;
            }
        }

        public static void RegisterAssembly<T>(this IWindsorContainer container, Assembly assembly, Action<ComponentRegistration> configurer) where T : class {
            container.Register(
                Classes.FromAssembly(assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<T>()
                    .Configure(configurer)
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
                );
        }

    }
}
