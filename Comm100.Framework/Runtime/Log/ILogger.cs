using System;
using System.Collections.Generic;
using System.Text;

namespace Comm100.Runtime
{
    public interface ILogger
    {
        void Info(string messsage);
        void Warn(string message);
        void Error(string message);
    }
}
