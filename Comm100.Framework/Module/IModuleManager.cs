using System;
using System.Collections.Generic;

namespace Comm100.Framework.Module
{
    public interface IModuleManager
    {
        ModuleInfo StartupModule { get; }

        IEnumerable<ModuleInfo> Modules { get; }

        void Initialize(Type startupModule);

        void StartModules();

        void ShutdownModules();
    }
}
