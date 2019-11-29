//-----------------------------------------------------------------------
// <copyright file="AuthorizationAttribute.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Authorization
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizationAttribute:Attribute
    {

        public Permission Permission { get; private set; }

        public AuthorizationAttribute(string source, AuthorizationType type)
        {
            this.Permission = new Permission(source, type);
        }
    }
}
