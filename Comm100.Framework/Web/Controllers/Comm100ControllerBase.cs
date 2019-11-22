using Comm100.Framework.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Comm100.Web.Controllers
{
    public class Comm100ControllerBase : ControllerBase
    {
        public Comm100ControllerBase()
        {

            Logger = NullLogger.Instance;
        }
        public ILogger Logger { get; set; }

    }
}
