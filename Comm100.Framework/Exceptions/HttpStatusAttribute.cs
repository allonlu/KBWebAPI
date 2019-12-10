using System;
using System.Net;

namespace Comm100.Framework.Exceptions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HttpStatusAttribute : Attribute
    {
        public HttpStatusCode Status { get; set; }

        public HttpStatusAttribute(HttpStatusCode status = HttpStatusCode.InternalServerError)
        {
            this.Status = status;
        }
    }
}
