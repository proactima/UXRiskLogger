using Ninject.Extensions.UXRiskLogger.Log4Net.Infrastructure;

namespace Ninject.Extensions.UXRiskLogger.Log4Net
{
    /// <summary>
    /// Extends the functionality of the kernel, providing integration between the Ninject
    /// logging infrastructure and log4net.
    /// </summary>
    public class Log4NetModule : LoggerModuleBase
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ILoggerFactory>().ToConstant(new Log4NetLoggerFactory());
            //this.Bind<ILogger>().To<Log4NetLogger>();
            base.Load();
        }
    }
}
