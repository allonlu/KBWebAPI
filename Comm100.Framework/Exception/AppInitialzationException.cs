using System;
namespace Comm100.Framework.Exception
{
    public class AppInitializationException : BaseException
    {
        private const int ERROR_APP_INITIALZATION = 100001;
        public AppInitializationException(string message) : base(ERROR_APP_INITIALZATION, message)
        {

        }
    }
}
