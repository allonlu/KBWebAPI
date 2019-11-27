//-----------------------------------------------------------------------
// <copyright file="NullLogger.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

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

        public void Warn(System.Exception exp, string message)
        {
        }

        public void Error(System.Exception exp, string message)
        {
        }

        public static ILogger Instance=>new NullLogger();
    }
}
