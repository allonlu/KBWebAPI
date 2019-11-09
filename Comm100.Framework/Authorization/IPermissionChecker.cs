using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm100.Runtime
{
    public interface IPermissionChecker
    {
        bool IsGranted(ISession session, string permission);
    }
}
