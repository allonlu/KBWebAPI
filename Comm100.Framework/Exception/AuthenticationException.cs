//-----------------------------------------------------------------------
// <copyright file="AuthenticationException.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Exception
{
    public class AuthenticationException : BaseException
    {
        public AuthenticationException() : base(401001, "")
        {

        }
    }
}
