//-----------------------------------------------------------------------
// <copyright file="AuthenticationException.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Net;
using Microsoft.AspNetCore.Http;

namespace Comm100.Framework.Exceptions
{
    [HttpStatus(HttpStatusCode.Unauthorized)]
    public class AuthenticationFailedException : BaseException
    {
        public AuthenticationFailedException() : base(ErrorMessages.AUTHENTICATION_FAILED)
        {
        }

        protected override void OnResponse(HttpContext context)
        {
            base.OnResponse(context);
        }
    }
}
