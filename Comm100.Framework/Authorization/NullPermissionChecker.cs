using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comm100.Framework.Authentication.Session;

namespace Comm100.Framework.Authorization
{
    public class NullPermissionChecker : IPermissionChecker
    {
        public bool IsGranted(ISession session, string source, EnumAuthorizationType type)
        {
            return true;
        }

        public static IPermissionChecker Instance => new NullPermissionChecker();
    }
}
