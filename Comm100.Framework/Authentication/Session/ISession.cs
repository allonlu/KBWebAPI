using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Framework.Authentication;

namespace Comm100.Runtime
{
   public interface ISession
    {
        EnumRole GetRole();

        string GetApplication();

        int? GetSiteId();

        Guid? GetAgentId();
    }
}
