using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Runtime
{
   public interface ISession
    {
        int GetAgentId();
        int GetSiteId();
    }
}
