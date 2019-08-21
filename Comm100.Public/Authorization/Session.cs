using Comm100.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm100.Public.Authorization
{
    public class Session : ISession
    {
        public int GetAgentId()
        {
            return 1;
        }

        public int GetSiteId()
        {
            return 1231;
        }
    }
}
