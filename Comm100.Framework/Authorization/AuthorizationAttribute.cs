using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Framework.Authorization
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizationAttribute:Attribute
    {
        public string Source { get; private set; }

        public EnumAuthorizationType Type { get; private set; }

        public AuthorizationAttribute(string source, EnumAuthorizationType type)
        {
            this.Source = source;
            this.Type = type;
        }
    }
}
