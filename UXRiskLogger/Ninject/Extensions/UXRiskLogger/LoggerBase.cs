using Ninject.Infrastructure.Disposal;
using System;

namespace Ninject.Extensions.UXRiskLogger
{
    /// <summary>
    /// Abstract base implementation of a logger.
    /// </summary>
    public abstract class LoggerBase : DisposableObject, ILogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerBase"/> class.
        /// </summary>
        /// <param name="type">The type to associate with the logger.</param>
        protected LoggerBase(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerBase"/> class.
        /// </summary>
        /// <param name="name">A custom name to use for the logger.  If null, the type's FullName will be used.</param>
        protected LoggerBase(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the type associated with the logger.
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets the name of the logger.
        /// </summary>
        public virtual string Name { get; private set; }

        /// <summary>
        /// Gets a value indicating whether messages with Debug severity should be logged.
        /// </summary>
        public abstract bool IsDebugEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Info severity should be logged.
        /// </summary>
        public abstract bool IsInfoEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Trace severity should be logged.
        /// </summary>
        public abstract bool IsTraceEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Warn severity should be logged.
        /// </summary>
        public abstract bool IsWarnEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Error severity should be logged.
        /// </summary>
        public abstract bool IsErrorEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Fatal severity should be logged.
        /// </summary>
        public abstract bool IsFatalEnabled { get; }

        /// <summary>
        /// Logs the specified message with Debug severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Debug(string message);
        /// <summary>
        /// Logs the specified exception with Debug severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public abstract void Debug(string message, Exception exception);

        /// <summary>
        /// Logs the specified message with Info severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Info(string message);
        /// <summary>
        /// Logs the specified exception with Info severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public abstract void Info(string message, Exception exception);

        /// <summary>
        /// Logs the specified message with Warn severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Warn(string message);
        /// <summary>
        /// Logs the specified message with Warn severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public abstract void Warn(string message, Exception exception);

        /// <summary>
        /// Logs the specified message with Error severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public abstract void Error(string message);
        /// <summary>
        /// Logs the specified exception with Error severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public abstract void Error(string message, Exception exception);

        public abstract void Debug(string message, string correlationId, Exception exception = null);
        public abstract void Debug(string message, double value, UnitType unitType, Exception exception = null);
        public abstract void Debug(string message, double value, UnitType unitType, string correlationId, Exception exception = null);

        public abstract void Info(string message, string correlationId, Exception exception = null);
        public abstract void Info(string message, double value, UnitType unitType, Exception exception = null);
        public abstract void Info(string message, double value, UnitType unitType, string correlationId, Exception exception = null);

        public abstract void Warn(string message, string correlationId, Exception exception = null);
        public abstract void Warn(string message, double value, UnitType unitType, Exception exception = null);
        public abstract void Warn(string message, double value, UnitType unitType, string correlationId, Exception exception = null);

        public abstract void Error(string message, string correlationId, Exception exception = null);
        public abstract void Error(string message, double value, UnitType unitType, Exception exception = null);
        public abstract void Error(string message, double value, UnitType unitType, string correlationId, Exception exception = null);
    }
}
