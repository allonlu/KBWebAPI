namespace Comm100.Application.Services
{
    using AutoMapper;
    using Castle.Core.Logging;
    using Comm100.Framework.Authentication.Session;

    public abstract class BaseAppService: IAppService
    {
        public BaseAppService()
        {
            this.Session = NullSession.Instance;
            this.Logger = NullLogger.Instance;
        }

        public ISession Session { get; set; }

        public ILogger Logger { get; set; }

        public IMapper Mapper { get; set; }
        
    }
}
