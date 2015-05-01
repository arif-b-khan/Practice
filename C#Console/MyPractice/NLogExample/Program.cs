using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NLogExample
{
    class Program
    {
        
       static NLog.Logger logger = LogManager.GetLogger("MyLogger");
        static void Main(string[] args)
        {
            GlobalDiagnosticsContext.Set("ApplicationName", "NLogExample");
            //logger.Debug("This is the message from console");
            //logger.Warn("warned");
            logger.Info("info", new Exception("Hello exception"));
            //logger.Error("Error");
        }
    }
}
