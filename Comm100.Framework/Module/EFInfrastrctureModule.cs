//-----------------------------------------------------------------------
// <copyright file="EFIocFacility.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Infrastructure
{
    using Comm100.Framework.Module;
    using Comm100.Framework.Extension;
    using Comm100.Domain.Uow;
    using Comm100.Framework.Domain.Repository;

    public class EFInfrastrctureModule : AbstractModule
    {
        public override void Initialize()
        {
            this.Container.RegisterIfNot(typeof(IRepository<,>), typeof(EFRepository<,>), DependencyLifeStyle.Scoped);
            this.Container.RegisterIfNot<IUnitOfWorkManager, EFUnitOfWorkManager>(DependencyLifeStyle.Scoped);
        }
    }
}