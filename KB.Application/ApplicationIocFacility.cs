using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Comm100.Application;
using Comm100.Framework.Logging;
using Comm100.Public.Authorization;
using Comm100.Runtime;
using KB.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace KB.Application
{
    public class ApplicationIocFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.AppServiceRegister(this.GetType().Assembly);

            DomainIocInitializer.Init(Kernel);

            Kernel.Register(
               Component.For(typeof(ILogger)).ImplementedBy(typeof(Logger))
                        .LifestyleScoped(),
               Component.For(typeof(ISession)).ImplementedBy(typeof(Session))
                            .LifestyleScoped(),
               Component.For(typeof(IPermissionChecker)).ImplementedBy(typeof(PermissionChecker))
                            .LifestyleScoped()  
                );
        }
    }
}
