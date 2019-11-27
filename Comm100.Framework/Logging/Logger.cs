//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Comm100.Framework.Logging
{
    public class DebugLogger : ILogger
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
