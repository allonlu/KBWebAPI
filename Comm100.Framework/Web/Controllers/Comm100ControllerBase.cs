using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Comm100.Domain.Ioc;
using Comm100.Runtime;
using Microsoft.AspNetCore.Mvc;

namespace Comm100.Web.Controllers
{
    public class Comm100ControllerBase : Controller
    {
        public Comm100ControllerBase()
        {

            Logger = NullLogger.Instance;
        }
        [Mandatory]
        public ILogger Logger { get; set; }

    }
}
