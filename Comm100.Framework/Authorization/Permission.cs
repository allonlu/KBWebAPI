using System;
namespace Comm100.Framework.Authorization
{
    public class Permission
    {
        public string Source { get; private set; }

        public AuthorizationType Type { get; private set; }

        public Permission(string source, AuthorizationType type)
        {
            this.Source = source;
            this.Type = type;
        }
    }
}
