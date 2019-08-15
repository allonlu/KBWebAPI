using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Runtime
{
    public class NullSession : ISession
    {
        public int GetAgentId()
        {
            throw new NotImplementedException();
        }

        public int GetSiteId()
        {
            throw new NotImplementedException();
        }
        public static ISession Instance => new NullSession();
    }
}
