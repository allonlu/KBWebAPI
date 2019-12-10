using System;
namespace Comm100.Framework.Exceptions
{
    public class AppInitializationException : BaseException
    {
        public AppInitializationException(string reason)
            : base(ErrorMessages.APP_INITIALIZATION_FAILED + " " + reason)
        {
        }
    }
}
