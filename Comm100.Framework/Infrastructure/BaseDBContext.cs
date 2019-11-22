using System;
using Comm100.Framework.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Comm100.Framework.Infrastructure
{
    public class BaseDBContext : DbContext
    {
        private string _connectString { get; set; }

        public Tenant Tenant { get; private set; }


        public BaseDBContext(IConfiguration configuration, ITenantProvider tenantProvider)
        {
            this._connectString = configuration.GetConnectionString("DefaultConnection");

            this.Tenant = tenantProvider.GetTenant();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectString)
                .AddInterceptors(new MultiTenantTableCommandInterceptor(Tenant));
        }
    }
}
