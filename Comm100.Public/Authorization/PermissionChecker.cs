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
    }
}
