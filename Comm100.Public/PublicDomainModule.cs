using System;
using Comm100.Framework.Authorization;
using Comm100.Framework.Module;
using Comm100.Framework.Extension;
using Comm100.Framework.Auditing;
using Comm100.Public.Auditing;
using Comm100.Public.Authorization;

namespace Comm100.Public
{
    public class PublicDomainModule : BaseDomainModule
    {
        public override void Initialize()
        {
            this.Container.RegisterIfNot<IAuthorizationProvider, AuthorizationProvider>(DependencyLifeStyle.Scoped);
            this.Container.RegisterIfNot<IAuditLogger, AuditLogger>(DependencyLifeStyle.Transient);
            base.Initialize();
        }
    }
}
