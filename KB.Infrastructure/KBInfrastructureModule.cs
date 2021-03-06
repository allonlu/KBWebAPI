using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Comm100.Framework.Module;
using Comm100.Framework.Extension;
using Comm100.Framework.Infrastructure;
using Comm100.Domain.Uow;

namespace KB.Infrastructure
{
    [DependsOn(typeof(EFInfrastrctureModule))]
    public class KBInfrastructureModule : AbstractModule
    {
        public override void PreInitialize()
        {
            this.Container.Register<IUnitOfWorkManager, DisabledUnitOfWorkManager>(DependencyLifeStyle.Scoped);
        }
        public override void Initialize()
        {
            this.Container.Register<BaseDBContext, KBDataContext>(DependencyLifeStyle.Scoped);
            }
    }
}
