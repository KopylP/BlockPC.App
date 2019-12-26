using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kopyl.BlockPC.App.Utils
{
    class ThreadableLogger : ILogger
    {
        private Logger _logger;

        public ThreadableLogger(Logger logger) => _logger = logger;

        public void Debug(string message)
        {
            var threadExecution = new Thread(() => _logger.Debug(message));
            threadExecution.Start();
        }

        public void Error(string message)
        {
            var threadExecution = new Thread(() => _logger.Error(message));
            threadExecution.Start();
        }

        public void Info(string message)
        {
            var threadExecution = new Thread(() => _logger.Info(message));
            threadExecution.Start();
        }
    }
}
