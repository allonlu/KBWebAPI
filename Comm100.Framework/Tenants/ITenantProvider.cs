//-----------------------------------------------------------------------
// <copyright file="ITenantProvider.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Tenants
{
    public interface ITenantProvider
    {
        Tenant GetTenant();
    }
}
