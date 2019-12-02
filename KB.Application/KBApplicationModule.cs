using System.Reflection;
using Comm100.Framework.Module;
using Comm100.Framework.Extension;
using KB.Domain;
using Comm100.Public.Enum;

namespace KB.Application
{
    [DependsOn(typeof(KBDomainModule))]
    public class KBApplicationModule : BaseApplicationModule
    {
        public KBApplicationModule()
            : base(ApplicationTypes.KB.ToString())
        {

        }
    }
}
