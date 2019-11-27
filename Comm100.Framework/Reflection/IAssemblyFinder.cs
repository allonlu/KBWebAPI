using System;
using System.Collections.Generic;
using System.Reflection;

namespace Comm100.Framework.Reflection
{
    public interface IAssemblyFinder
    {
        List<Assembly> GetAllAssemblies();
    }
}
