


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comm100.Framework.Logging
{
    public class Logger : ILogger
    {
        public void Debug(string message)
        {
            System.Diagnostics.Debug.Print("Debug:" + message);
        }

        public void Info(string message)
        {
            System.Diagnostics.Debug.Print("Info:" + message);
        }

        public void Warn(string message)
        {
            System.Diagnostics.Debug.Print("Warn:" + message);
        }

        public void Error(string message)
        {
            System.Diagnostics.Debug.Print("Error:" + message);
        }
    }
}
