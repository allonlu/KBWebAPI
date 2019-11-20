using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Framework.Authentication;

namespace Comm100.Framework.Authentication.Session
{
   public interface ISession
    {
        Role GetRole();

        string GetApplication();

        int? GetSiteId();

        Guid? GetAgentId();

        string GetIP();
    }
}
