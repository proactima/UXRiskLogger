using log4net.Config;
using Ninject;
using Ninject.Extensions.UXRiskLogger;
using Ninject.Extensions.UXRiskLogger.Autologger;
using Ninject.Extensions.UXRiskLogger.Log4Net;
using System;
using System.Reflection;

namespace ConsoleLoggingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  You should look at the following files to get an idea about what's happening
             *  Program.cs (this file):     Here we configure Log4Net, inject our logger (UXRiskLogger) with Ninject,
             *                              grab the logger so we can use it straigth away and do some basic logging
             *  CustomPatternConverter.cs:  Reads out our custom properties that we define in the UXRiskLogger project
             *  App.config:                 Configures Log4Net and our CustomPatternConverter
             */

            // Read Log4Net config from App.config
            XmlConfigurator.Configure();

            // Inject the logger module with Ninject. This have the benefil that in the other classes you can reach the logger by doing
            // public ILogger Logger { get; set; } inside your class
            // and then log by doing Logger.Info()
            var kernel = new StandardKernel(new Log4NetModule(), new AutomaticLoggingInjectionModule());

            // Since we're doing logging in the application startup, the Injection isn't done yet, and we need to access
            // the logger a bit more manually here.
            var log = kernel.Get<ILoggerFactory>().GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            var access = kernel.Get<AccessLogger>();

            // Debug log with "Testmessage" as message and "CorID" as Properties["correlationId"]
            log.Debug("Testmessage", Guid.NewGuid().ToString());

            // Info log with "Application started" as message, 43254,32 as Properties["value"] and UnitType.bytes as Properties["unitType"]
            log.Info("Application started", 43254.32, UnitType.bytes);

            // Log from AccessLogger class
            access.DoLog();

            // Wait on keypress to exit.
            Console.ReadLine();
        }
    }
}
