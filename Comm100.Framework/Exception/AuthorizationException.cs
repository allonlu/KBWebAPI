using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Comm100.Runtime.Exception
{
    public class AuthorizationException : Comm100Exception
    {
        public AuthorizationException():base(100102, ErrorMessages.E100102)
        {
        }
    }
}
