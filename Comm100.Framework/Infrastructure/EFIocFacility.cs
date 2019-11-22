//-----------------------------------------------------------------------
// <copyright file="EFIocFacility.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Infrastructure
{
    using Castle.MicroKernel.Facilities;
    using Castle.MicroKernel.Registration;
    using Comm100.Framework.Domain.Repository;
    using Comm100.Domain.Uow;

    public class EFIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
                Component.For(typeof(IRepository<,>))
                         .ImplementedBy(typeof(EFRepository<,>))
                         .LifestyleScoped(),
                Component.For(typeof(IUnitOfWorkManager))
                         .ImplementedBy(typeof(EFUnitOfWorkManager))
                         .LifestyleScoped()
            );
        }
    }
}