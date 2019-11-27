using Comm100.Framework.Module;
using Comm100.Framework.Extension;
using System.Reflection;
using Comm100.Public;

namespace KB.Domain
{
    [DependsOn(typeof(PublicDomainModule))]
    public class KBDomainModule : BaseDomainModule
    {
    }
}
