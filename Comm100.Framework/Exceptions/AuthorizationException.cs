//-----------------------------------------------------------------------
// <copyright file="AuthorizationException.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Net;

namespace Comm100.Framework.Exceptions
{
    [HttpStatus(HttpStatusCode.Forbidden)]
    public class AuthorizationException : BaseException
    {
        public AuthorizationException()
            : base(ErrorMessages.NO_SUFFICIENT_PERMISSION)
        {
        }

        public AuthorizationException(string permission)
            : base(string.Format(ErrorMessages.NO_SUFFICIENT_PERMISSION, permission))
        {
        }
    }
}
