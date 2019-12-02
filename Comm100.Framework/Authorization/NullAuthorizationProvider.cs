//-----------------------------------------------------------------------
// <copyright file="NullPermissionChecker.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Comm100.Framework.Authorization
{
    public class NullAuthorizationProvider : IAuthorizationProvider
    {
        public static NullAuthorizationProvider Instance => new NullAuthorizationProvider();

        public bool IsGranted(string application, string[] permissions)
        {
            return true;
        }
    }
}
