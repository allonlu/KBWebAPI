using System;
using Castle.Core;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using Comm100.Domain.Uow;
using Comm100.Framework.Application.Interceptors;
using Comm100.Framework.Authorization;
using Comm100.Framework.Extension;

namespace Comm100.Framework.Module
{
    public class KernelModule : AbstractModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
        }

        public override void PostInitialize()
        {
            RegisterMissingComponents();
        }

        public override void Shutdown()
        {
        }


        private void RegisterMissingComponents()
        {
            Container.RegisterIfNot<ILogger, NullLogger>(DependencyLifeStyle.Singleton);
            Container.RegisterIfNot<IAuthorizationProvider, NullAuthorizationProvider>(DependencyLifeStyle.Scoped);
        }
    }
}
