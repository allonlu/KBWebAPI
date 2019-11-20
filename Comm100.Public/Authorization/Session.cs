using Comm100.Framework.Authentication;
using Comm100.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm100.Framework.Authentication.Session
{
    public class Session : ISession
    {
        public string GetApplication()
        {
            throw new NotImplementedException();
        }

        public string GetIP()
        {
            throw new NotImplementedException();
        }

        public Role GetRole()
        {
            throw new NotImplementedException();
        }

        Guid? ISession.GetAgentId()
        {
            throw new NotImplementedException();
        }

        int? ISession.GetSiteId()
        {
            throw new NotImplementedException();
        }
    }
}
