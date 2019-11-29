using System;
namespace Comm100.Framework.Authorization
{
    public interface IPermissionProvider
    {
        bool Write(string source);

        bool Read(string source);
    }
}
