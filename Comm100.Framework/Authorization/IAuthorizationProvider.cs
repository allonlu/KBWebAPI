using System;
using System.Collections.Generic;

namespace Comm100.Framework.Authorization
{
    public interface IAuthorizationProvider
    {
        bool IsGranted(string application, string[] permissions);
    }
}
