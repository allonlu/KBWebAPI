namespace Comm100.Framework.Exceptions
{
    public class IsolationLevelException : BaseException
    {
        public IsolationLevelException()
            :base (ErrorMessages.WRONG_ISOLATION)
        {
        }
    }
}
