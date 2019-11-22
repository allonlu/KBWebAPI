//-----------------------------------------------------------------------
// <copyright file="AuthorizationException.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Exception
{
    public class AuthorizationException : BaseException
    {
        public AuthorizationException():base(100102, ErrorMessages.E100102)
        {
        }
    }
}
