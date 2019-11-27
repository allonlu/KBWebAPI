namespace Comm100.Framework.Authorization
{
    using Comm100.Framework.Authentication.Session;

    public interface IPermissionChecker
    {
        bool IsGranted(ISession session, string source, AuthorizationType type);
    }
}
