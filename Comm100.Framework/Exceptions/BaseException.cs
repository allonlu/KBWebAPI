//------------------------------lic -----------------------------------------
// <copyright file="BaseException.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Exceptions
{
    using System;
    using System.Net;
    using Microsoft.AspNetCore.Http;

    public class BaseException : Exception
    {
        public string Name => this.GetType().Name;

        public int StatusCode
        {
            get
            {
                // TODO
                // read from attribute
                return (int)HttpStatusCode.InternalServerError;
            }
        }

        public BaseException(string message)
            :base(message)
        {
        }

        protected virtual HttpStatusCode Status
        {
            get { return HttpStatusCode.InternalServerError; }
        }

        protected virtual void OnResponse(HttpContext context)
        {

        }
    }
}
