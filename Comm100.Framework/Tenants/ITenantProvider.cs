using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Framework.Tenants
{
    public interface ITenantProvider
    {
        Tenant GetTenant();
    }
}
