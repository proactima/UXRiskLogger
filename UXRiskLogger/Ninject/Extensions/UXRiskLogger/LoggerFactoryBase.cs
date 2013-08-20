﻿using Ninject.Activation;
using Ninject.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Ninject.Extensions.UXRiskLogger
{
    /// <summary>
    /// A baseline definition of a logger factory, which tracks loggers as flyweights by type.
    /// Custom logger factories should generally extend this type.
    /// </summary>
    public abstract class LoggerFactoryBase : NinjectComponent, ILoggerFactory
    {
        /// <summary>
        /// Maps types to loggers.
        /// </summary>
        private readonly Dictionary<Type, ILogger> loggersByType = new Dictionary<Type, ILogger>();

        /// <summary>
        /// Maps names to loggers.
        /// </summary>
        private readonly Dictionary<string, ILogger> loggersByName = new Dictionary<string, ILogger>();

        /// <summary>
        /// Gets the logger for the specified type, creating it if necessary.
        /// </summary>
        /// <param name="type">The type to create the logger for.</param>
        /// <returns>The newly-created logger.</returns>
        public ILogger GetLogger(Type type)
        {
            lock (this.loggersByType)
            {
                if (this.loggersByType.ContainsKey(type))
                {
                    return this.loggersByType[type];
                }

                ILogger logger = this.CreateLogger(type);
                this.loggersByType.Add(type, logger);

                return logger;
            }
        }

        /// <summary>
        /// Gets a custom-named logger for the specified type, creating it if necessary.
        /// </summary>
        /// <param name="name">The explicit name to create the logger for.  If null, the type's FullName will be used.</param>
        /// <returns>The newly-created logger.</returns>
        public ILogger GetLogger(string name)
        {
            lock (this.loggersByName)
            {
                if (this.loggersByName.ContainsKey(name))
                {
                    return this.loggersByName[name];
                }

                ILogger logger = this.CreateLogger(name);
                this.loggersByName.Add(name, logger);

                return logger;
            }
        }

        /// <summary>
        /// Gets the logger for the specified activation context, creating it if necessary.
        /// </summary>
        /// <param name="context">The ninject creation context.</param>
        /// <returns>The newly-created logger.</returns>
        public ILogger GetLogger(IContext context)
        {
            return this.GetLogger(context.Request.Target.Member.DeclaringType);
        }

#if !SILVERLIGHT && !NETCF
        /// <summary>
        /// The method info for GetCurrentClassLogger
        /// </summary>
        private static readonly MethodInfo getCurrentClassLoggerMethodInfo =
            typeof(LoggerFactoryBase).GetMethod("GetCurrentClassLogger", BindingFlags.Public | BindingFlags.Instance);

        /// <summary>
        /// Gets the logger for the class calling this method.
        /// </summary>
        /// <returns>The newly-created logger.</returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public ILogger GetCurrentClassLogger()
        {
            var frame = new StackFrame(0, false);
            if (frame.GetMethod() == getCurrentClassLoggerMethodInfo)
            {
                frame = new StackFrame(1, false);
            }

            var type = frame.GetMethod().DeclaringType;

            if (type == null)
            {
                throw new InvalidOperationException(string.Format("Can not determine current class. Method: {0}", frame.GetMethod()));
            }

            return this.GetLogger(type);
        }
#endif

        /// <summary>
        /// Creates a logger for the specified type.
        /// </summary>
        /// <param name="type">The type to create the logger for.</param>
        /// <returns>The newly-created logger.</returns>
        protected abstract ILogger CreateLogger(Type type);

        /// <summary>
        /// Creates a logger with the specified name.
        /// </summary>
        /// <param name="name">The explicit name to create the logger for.  If null, the type's FullName will be used.</param>
        /// <returns>The newly-created logger.</returns>
        protected abstract ILogger CreateLogger(string name);
    }
}
