using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Domain.Ioc;
using Comm100.Runtime;
using Microsoft.AspNetCore.Mvc;

namespace Comm100.Web.Controllers
{
    public class Comm100ControllerBase : ControllerBase
    {
        public Comm100ControllerBase()
        {

            Logger = NullLogger.Instance;
        }
        [Mandatory]
        public ILogger Logger { get; set; }

    }
}
