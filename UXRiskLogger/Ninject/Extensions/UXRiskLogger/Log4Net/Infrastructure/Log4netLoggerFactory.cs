using System;

namespace Ninject.Extensions.UXRiskLogger.Log4Net.Infrastructure
{
    /// <summary>
    /// An implementation of a logger factory that creates <see cref="Log4NetLogger"/>s.
    /// </summary>
    public class Log4NetLoggerFactory : LoggerFactoryBase
    {
        /// <summary>
        /// Creates a logger for the specified type.
        /// </summary>
        /// <param name="type">The type to create the logger for.</param>
        /// <returns>The newly-created logger.</returns>
        protected override ILogger CreateLogger(Type type)
        {
            return new Log4NetLogger(type);
        }

        /// <summary>
        /// Creates a logger with the specified name.
        /// </summary>
        /// <param name="name">The explicit name to create the logger for.  If null, the type's FullName will be used.</param>
        /// <returns>The newly-created logger.</returns>
        protected override ILogger CreateLogger(string name)
        {
            return new Log4NetLogger(name);
        }
    }
}
