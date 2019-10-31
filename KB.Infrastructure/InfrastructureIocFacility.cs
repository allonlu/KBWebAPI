using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using KB.Infrastructure.Tenants;

namespace KB.Infrastructure
{
    public class InfrastructureIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
               Component.For(typeof(DbContext))
                        .ImplementedBy(typeof(KBDataContext))
                        .LifestyleScoped(),
               Component.For(typeof(ITenantProvider))
                         .ImplementedBy(typeof(TenantProvider))
                         .LifestyleScoped()
                );
        }
    }
}
