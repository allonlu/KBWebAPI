using Comm100.Framework.Authentication.Session;
using Comm100.Framework.Authorization;
using Comm100.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm100.Public.Authorization
{
    public class PermissionChecker : IPermissionChecker
    {

        public bool IsGranted(ISession session, string permission)
        {
            return true;
        }

        public bool IsGranted(ISession session, string source, EnumAuthorizationType type)
        {
            throw new NotImplementedException();
        }
    }
}
