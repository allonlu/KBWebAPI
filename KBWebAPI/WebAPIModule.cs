using System;
using Comm100.Framework.Module;
using Comm100.Framework.Tenants;
using Comm100.Framework.Web;
using Comm100.Framework.Extension;
using KB.Application;
using KB.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace KB.WebAPI
{
    [DependsOn(typeof(KBApplicationModule), typeof(KBInfrastructureModule))]
    public class WebAPIModule : AbstractModule
    {
        public override void Initialize()
        {
            this.Container.Register<IHttpContextAccessor, HttpContextAccessor>();
            this.Container.Register<ITenantProvider, TenantProvider>(DependencyLifeStyle.Scoped);
        }
    }
}