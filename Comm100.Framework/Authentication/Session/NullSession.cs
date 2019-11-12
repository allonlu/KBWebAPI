using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Framework.Authentication;

namespace Comm100.Framework.Authentication.Session
{
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

        public EnumRole GetRole()
        {
            return EnumRole.system;
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
