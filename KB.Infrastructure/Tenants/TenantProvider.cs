using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Infrastructure.Tenants
{
    public class TenantProvider : ITenantProvider
    {
        private Tenant _tenant;
        public TenantProvider(IHttpContextAccessor accessor)
        {
            var host = accessor.HttpContext.Request.Host.Value;
            var id = Convert.ToInt32(accessor.HttpContext.Request.Query["siteId"]);  // get from db by host if use subdomain

            this._tenant = new Tenant()
            {
                Id = id,
                Host = host
            };
        }

        public Tenant GetTenant()
        {
            return _tenant;
        }
    }
}
