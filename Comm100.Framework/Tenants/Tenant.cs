using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Framework.Tenants
{
    public class Tenant
    {
        public int Id { get; set; }

        public string DatabaseName { get; set; }

        public string Host { get; set; }
    }
}
