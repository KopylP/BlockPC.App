using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopyl.BlockPC.App.Utils
{
    class Logger: ILogger
    {

        enum LogType
        {
            INFO,
            DEBUG,
            ERROR
        }

        public string LogFilePath { get; set; } = "D:\\blockpc.log";
        object obj = new object();
        private void RecordEntry(string message, LogType logType)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter(LogFilePath, true))
                {
                    writer.WriteLine($"[{logType}]: {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")} {message}");
                    writer.Flush();
                }
            }
        }

        public void Info(string message) => RecordEntry(message, LogType.INFO);
        public void Debug(string message) => RecordEntry(message, LogType.DEBUG);
        public void Error(string message) => RecordEntry(message, LogType.ERROR);

    }
}
