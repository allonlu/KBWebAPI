﻿namespace Comm100.Web.Filters
{
    using System.Net;
    using Comm100.Framework.Exception;
    using Comm100.Framework.Logging;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class Comm100ExceptionFilter : IExceptionFilter
    {
        public ILogger Logger { get; set; }

        public void OnException(ExceptionContext context)
        {
            //Logger.Error(context.Exception.Message);

            if (!(context.ActionDescriptor is ControllerActionDescriptor))
            {
                return;
            }

            context.HttpContext.Response.StatusCode = GetStatusCode(context);

            var myException = context.Exception as BaseException;
            if (myException == null)
                context.Result = new ObjectResult(
                    new { 
                        ErrorCode = 10009, 
                        Message = context.Exception.Message + context.Exception.InnerException.Message,
                    });
            else
                context.Result = new ObjectResult(new { ErrorCode = myException.ErrorCode, Message = myException.Message });

            context.Exception = null;
        }

        private int GetStatusCode(ExceptionContext context)
        {
            //通过检查Context.Exception的类型，返回不同的StatusCode.
            if (context.Exception is EntityNotFoundException)
            {
                return (int)HttpStatusCode.NotFound;
            }
            if (context.Exception is AuthorizationException)
            {
                return (int)HttpStatusCode.Unauthorized;
            }

            return (int)HttpStatusCode.InternalServerError;
        }
    }
}
