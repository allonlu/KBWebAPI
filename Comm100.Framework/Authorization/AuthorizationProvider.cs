//-----------------------------------------------------------------------
// <copyright file="PermissionChecker.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Authorization
{
    using System;
    using System.Collections.Generic;

    public class AuthorizationProvider : IAuthorizationProvider
    {
        private IPermissionProvider _provider;

        public AuthorizationProvider(IPermissionProvider provider)
        {
            this._provider = provider;
        }

        public bool IsGranted(IEnumerable<Permission> permissions)
        {
            foreach(Permission permission in permissions)
            {
                if (permission.Type == AuthorizationType.WRITE && !_provider.Write(permission.Source))
                {
                    return false;
                }

                if (permission.Type == AuthorizationType.READ && !_provider.Read(permission.Source))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
