using System;
using NLog;
using NLog.Web;

namespace Comm100.Framework.Logging
{
    public class NLogger : ILogger
    {
        private Logger _logger;

        public NLogger()
        {
            _logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public static void Shotdown()
        {
            NLog.LogManager.Shutdown();
        }

        public void Warn(System.Exception exp, string message)
        {
            _logger.Warn(exp, message);
        }

        public void Error(System.Exception exp, string message)
        {
            _logger.Error(exp, message);
        }
    }
}
