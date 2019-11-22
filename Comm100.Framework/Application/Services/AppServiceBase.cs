namespace Comm100.Application.Services
{
    using AutoMapper;
    using Castle.Core.Logging;
    using Comm100.Framework.Authentication.Session;
    using Comm100.Framework.Authorization;

    public abstract class AppServiceBase: IAppService
    {
        public AppServiceBase()
        {
            this.Session = NullSession.Instance;
            this.PermissionChecker = NullPermissionChecker.Instance;
            this.Logger = NullLogger.Instance;
        }

        public ISession Session { get; set; }
        public IPermissionChecker PermissionChecker { get; set; }
        public ILogger Logger { get; set; }

        public IMapper Mapper { get; set; }
        
    }
}
