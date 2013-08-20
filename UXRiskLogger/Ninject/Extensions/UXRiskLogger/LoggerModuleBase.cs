using Ninject.Modules;

namespace Ninject.Extensions.UXRiskLogger
{
    /// <summary>
    /// Base implementation for logger modules
    /// </summary>
    public abstract class LoggerModuleBase : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<ILogger>().ToMethod(context => context.Kernel.Get<ILoggerFactory>().GetLogger(context));
        }
    }
}
