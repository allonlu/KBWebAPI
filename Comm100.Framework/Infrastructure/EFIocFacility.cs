using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Comm100.Framework.Domain.Repository;
using Comm100.Domain.Uow;
using Microsoft.EntityFrameworkCore;

namespace Comm100.Framework.Infrastructure
{
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