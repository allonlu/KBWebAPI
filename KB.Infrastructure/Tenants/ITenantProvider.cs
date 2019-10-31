using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Infrastructure.Tenants
{
    public interface ITenantProvider
    {
        Tenant GetTenant();
    }
}
