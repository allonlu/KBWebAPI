namespace Comm100.Framework.Authentication.Session
{
    using System;

    public class NullSession : ISession
    {
        public static ISession Instance => new NullSession();

        public Guid? GetAgentId()
        {
            return null;
        }

        public string GetApplication()
        {
            return null;
        }

        public Role GetRole()
        {
            return Role.SYSTEM;
        }

        public int? GetSiteId()
        {
            return null;
        }

        public string GetIP()
        {
            return "";
        }
    }
}
