//-----------------------------------------------------------------------
// <copyright file="AuthorizationAttribute.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Authorization
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizationAttribute:Attribute
    {
        public string[] Permissions { get; private set; }

        public AuthorizationAttribute(params string[] permissions)
        {
            this.Permissions = permissions;
        }
    }
}
