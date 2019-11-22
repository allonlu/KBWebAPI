//-----------------------------------------------------------------------
// <copyright file="ILogger.cs" company="Comm100 Network Corporation">
//     Copyright (c) Comm100 Network Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

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
