using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comm100.Framework.Authentication.Session;

namespace Comm100.Framework.Authorization
{
    public interface IPermissionChecker
    {
        bool IsGranted(ISession session, string source, AuthorizationType type);
    }
}
