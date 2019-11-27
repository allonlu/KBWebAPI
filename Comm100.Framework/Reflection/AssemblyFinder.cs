﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Comm100.Framework.Module;

namespace Comm100.Framework.Reflection
{
    public class AssemblyFinder : IAssemblyFinder
    {
        private readonly IModuleManager _moduleManager;

        public AssemblyFinder(IModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
        }

        public List<Assembly> GetAllAssemblies()
        {
            var assemblies = new List<Assembly>();

            foreach (var module in _moduleManager.Modules)
            {
                assemblies.Add(module.Assembly);
                assemblies.AddRange(module.Instance.GetAdditionalAssemblies());
            }

            return assemblies.Distinct().ToList();
        }
    }
}
