﻿//-----------------------------------------------------------------------
// <copyright file="PermissionChecker.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Authorization
{
    using Comm100.Framework.Authentication.Session;

    public class PermissionChecker : IPermissionChecker
    {
        public bool IsGranted(ISession session, string source, AuthorizationType type)
        {
            return true;
        }
    }
}
