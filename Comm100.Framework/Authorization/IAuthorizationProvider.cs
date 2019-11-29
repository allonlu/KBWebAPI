namespace Comm100.Framework.Authorization
{
    using System.Collections.Generic;

    public interface IAuthorizationProvider
    {
        bool IsGranted(IEnumerable<Permission> permissions);
    }
}
