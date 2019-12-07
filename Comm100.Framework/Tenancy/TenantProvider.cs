//-----------------------------------------------------------------------
// <copyright file="TenantProvider.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Tenancy
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Concurrent;

    public class TenancyResolver : ITenancyResolver
    {
        private static ConcurrentDictionary<int, Tenant> tenants = new ConcurrentDictionary<int, Tenant>(); // cache tenant config

        private Tenant _tenant = null;

        public TenancyResolver(IHttpContextAccessor accessor)
        {
            var host = accessor.HttpContext.Request.Host.Value;

            // get from database by host if use subdomain, if complete the site database merge, also need get the database name from the database
            var id = Convert.ToInt32(accessor.HttpContext.Request.Query["siteId"]);

            this._tenant = tenants.GetOrAdd(id, new Tenant()
            {
                Id = id,
                DatabaseName = GetDbName(id),
                Host = host
            });
        }

        private string GetDbName(int siteId)    // read from db
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
