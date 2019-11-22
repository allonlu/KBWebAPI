using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Comm100.Application;
using Comm100.Framework.Logging;
using KB.Domain;
using Comm100.Framework.Authentication.Session;
using Comm100.Framework.Authorization;

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
