using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Framework.Logging
{
    public interface ILogger
    {
        void Debug(string message);

        void Info(string messsage);

        void Warn(string message);

        void Error(string message);
    }
}
