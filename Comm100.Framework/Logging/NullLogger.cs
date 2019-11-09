using System;
using System.Collections.Generic;
using System.Text;
using Comm100.Framework.Logging;

namespace Comm100.Framework.Logging
{
    public class NullLogger : ILogger
    {
        public void Debug(string message)
        {
        }

        public void Error(string message)
        {
        }

        public void Info(string messsage)
        {
        }

        public void Warn(string message)
        {
        }

        public static ILogger Instance=>new NullLogger();
    }
}
