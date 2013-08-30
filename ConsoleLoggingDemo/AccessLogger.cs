using Ninject.Extensions.UXRiskLogger;
using System;

namespace ConsoleLoggingDemo
{
    public class AccessLogger
    {
        public ILogger Logger { get; set; }

        public void DoLog()
        {
            try
            {
                throw new Exception("EXCEPTION FROM ACCESS");
                Logger.Info("Logging from AccessLogger");
            }
            catch (Exception e)
            {
                Logger.Info("ExceptionTest", "Corr", e);
            }
        }
    }
}
