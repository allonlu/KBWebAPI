using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using KB.Application;
using KB.Infrastructure;
using Comm100.Framework.Infrastructure;


namespace KB.WebAPI
{
    public class IocInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            //container.AddFacility<Comm100IocFacility>();
            container.AddFacility<InfrastructureIocFacility>();
            container.AddFacility<EFIocFacility>();
            container.AddFacility<ApplicationIocFacility>();
            
            
        }
    }
}