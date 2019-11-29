using System;
using Comm100.Framework.Authorization;
using Comm100.Framework.Module;
using Comm100.Framework.Extension;
using Comm100.Public.Permission;
using Comm100.Framework.Auditing;
using Comm100.Public.Auditing;

namespace Comm100.Public
{
    public class PublicDomainModule : BaseDomainModule
    {
        public override void Initialize()
        {
            this.Container.RegisterIfNot<IPermissionProvider, PermissionProvider>(DependencyLifeStyle.Scoped);
            this.Container.RegisterIfNot<IAuditLogger, AuditLogger>(DependencyLifeStyle.Transient);
            base.Initialize();
        }
    }
}
