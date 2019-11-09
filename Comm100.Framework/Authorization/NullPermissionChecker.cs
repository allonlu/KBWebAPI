using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm100.Runtime
{
    public class NullPermissionChecker : IPermissionChecker
    {
        public bool IsGranted(ISession session, string permission)
        {
            return true;
        }

        public static IPermissionChecker Instance => new NullPermissionChecker();
    }
}
