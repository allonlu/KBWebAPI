using System;
using Comm100.Runtime.Exception;

namespace Comm100.Framework.Exception
{
    public class AuthenticationException : Comm100Exception
    {
        public AuthenticationException() : base(401001, "")
        {

        }
    }
}
