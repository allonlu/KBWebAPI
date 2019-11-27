using System.Reflection;
using Comm100.Framework.Module;
using Comm100.Framework.Extension;
using KB.Domain;

namespace KB.Application
{
    [DependsOn(typeof(KBDomainModule))]
    public class KBApplicationModule : BaseApplicationModule
    {
    }
}
