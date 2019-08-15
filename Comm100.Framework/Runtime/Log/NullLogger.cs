using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Runtime
{
    public class NullLogger : ILogger
    {
        public void Error(string message)
        {
            throw new NotImplementedException();
        }

        public void Info(string messsage)
        {
            throw new NotImplementedException();
        }

        public void Warn(string message)
        {
            throw new NotImplementedException();
        }
        public static ILogger Instance=>new NullLogger();
    }
}
