namespace Comm100.Web.Filters
{
    using System.Net;
    using Comm100.Framework.Exceptions;
    using Comm100.Framework.Logging;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Controllers;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ApiExceptionFilter : IExceptionFilter
    {
        public ILogger Logger { get; set; }

        public void OnException(ExceptionContext context)
        {
            //Logger.Error(context.Exception.Message);

            if (!(context.ActionDescriptor is ControllerActionDescriptor))
            {
                return;
            }

            var myException = context.Exception as BaseException;

            if (myException == null)
            {
                context.Result = new ObjectResult(
                    new {
                        error = context.GetType().Name,
                        message = context.Exception.Message,
                    }) ;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else
            {
                context.Result = new ObjectResult(
                    new {
                        error = myException.Name,
                        message = myException.Message
                    });
                context.HttpContext.Response.StatusCode = myException.StatusCode;
            }
                

            context.Exception = null;
        }
    }
}
