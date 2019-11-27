using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Castle.Core.Logging;
using Castle.Windsor;
using Comm100.Framework.Exception;
using Comm100.Framework.Extension;

namespace Comm100.Framework.Module
{
    public class ModuleManager : IModuleManager
    {
        public ModuleInfo StartupModule { get; private set; }

        public IEnumerable<ModuleInfo> Modules => _modules.ToImmutableList();

        public ILogger Logger { get; set; }

        private ModuleCollection _modules;

        private readonly IWindsorContainer _iocContainer;

        public ModuleManager(IWindsorContainer iocContainer)
        {
            _iocContainer = iocContainer;

            Logger = NullLogger.Instance;
        }

        public virtual void Initialize(Type startupModule)
        {
            _modules = new ModuleCollection(startupModule);
            LoadAllModules();
        }

        public virtual void StartModules()
        {
            var sortedModules = _modules.GetSortedModuleListByDependency();
            sortedModules.ForEach(module => module.Instance.PreInitialize());
            sortedModules.ForEach(module => module.Instance.Initialize());
            sortedModules.ForEach(module => module.Instance.PostInitialize());
        }

        public virtual void ShutdownModules()
        {
            Logger.Debug("Shutting down has been started");

            var sortedModules = _modules.GetSortedModuleListByDependency();
            sortedModules.Reverse();
            sortedModules.ForEach(sm => sm.Instance.Shutdown());

            Logger.Debug("Shutting down completed.");
        }

        private void LoadAllModules()
        {
            Logger.Debug("Loading modules...");

            var moduleTypes = AbstractModule.FindDependedModuleTypesRecursivelyIncludingGivenModule(_modules.StartupModuleType)
                .Distinct().ToList();

            Logger.Debug("Found " + moduleTypes.Count + " modules in total.");

            RegisterModules(moduleTypes);

            CreateModules(moduleTypes);

            _modules.EnsureKernelModuleToBeFirst();

            _modules.EnsureStartupModuleToBeLast();

            SetDependencies();

            Logger.DebugFormat("{0} modules loaded.", _modules.Count);
        }

        private void CreateModules(ICollection<Type> moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                var moduleObject = _iocContainer.Resolve(moduleType) as AbstractModule;
                if (moduleObject == null)
                {
                    throw new AppInitializationException("This type is not a module: " + moduleType.AssemblyQualifiedName);
                }

                moduleObject.Container = _iocContainer;

                var moduleInfo = new ModuleInfo(moduleType, moduleObject);

                _modules.Add(moduleInfo);

                if (moduleType == _modules.StartupModuleType)
                {
                    StartupModule = moduleInfo;
                }

                Logger.DebugFormat("Loaded module: " + moduleType.AssemblyQualifiedName);
            }
        }

        private void RegisterModules(ICollection<Type> moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                _iocContainer.RegisterIfNot(moduleType);
            }
        }

        private void SetDependencies()
        {
            foreach (var moduleInfo in _modules)
            {
                moduleInfo.Dependencies.Clear();

                //Set dependencies for defined DependsOnAttribute attribute(s).
                foreach (var dependedModuleType in AbstractModule.FindDependedModuleTypes(moduleInfo.Type))
                {
                    var dependedModuleInfo = _modules.FirstOrDefault(m => m.Type == dependedModuleType);
                    if (dependedModuleInfo == null)
                    {
                        throw new AppInitializationException("Could not find a depended module " + dependedModuleType.AssemblyQualifiedName + " for " + moduleInfo.Type.AssemblyQualifiedName);
                    }

                    if ((moduleInfo.Dependencies.FirstOrDefault(dm => dm.Type == dependedModuleType) == null))
                    {
                        moduleInfo.Dependencies.Add(dependedModuleInfo);
                    }
                }
            }
        }
    }
}
