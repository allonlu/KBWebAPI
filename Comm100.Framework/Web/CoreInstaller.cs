using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Comm100.Framework.Module;
using Comm100.Framework.Extension;
using Comm100.Framework.Reflection;

namespace Comm100.Framework.Web
{
    public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register<ITypeFinder, TypeFinder>();
            container.Register<IAssemblyFinder, AssemblyFinder>();
            container.Register<IModuleManager, ModuleManager>();
        }
    }
}
