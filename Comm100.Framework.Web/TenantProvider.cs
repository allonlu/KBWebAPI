using Comm100.Framework.Tenants;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Framework.Web
{
    public class TenantProvider : ITenantProvider
    {
        private Tenant _tenant;

        public TenantProvider(IHttpContextAccessor accessor)
        {
            var host = accessor.HttpContext.Request.Host.Value;

            // get from database by host if use subdomain, if complete the site database merge, also need get the database name from the database
            var id = Convert.ToInt32(accessor.HttpContext.Request.Query["siteId"]);
            
            this._tenant = new Tenant()
            {
                Id = id,
                DatabaseName = GetDbName(id),
                Host = host
            };
        }

        private string GetDbName(int siteId)
        {
            if(siteId > 0)
            {
                return "KB" + (siteId / 500 + 1);
            }
            return "KB";
        }

        public Tenant GetTenant()
        {
            return _tenant;
        }
    }
}
