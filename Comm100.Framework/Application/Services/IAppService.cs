namespace Comm100.Application.Services
{
    using Comm100.Framework.Authentication.Session;

    public interface IAppService
    {
        ISession Session { get; set; }
    }
}
