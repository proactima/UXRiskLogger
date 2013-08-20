using log4net;
using log4net.Core;
using System;
using System.Diagnostics;
using System.Threading;

namespace Ninject.Extensions.UXRiskLogger.Log4Net.Infrastructure
{
    /// <summary>
    /// A logger that integrates with log4net, passing all messages to an <see cref="ILog"/>.
    /// </summary>
    public class Log4NetLogger : LoggerBase
    {
        /// <summary>
        /// The logger used by this instance.
        /// </summary>
        private readonly ILog log4NetLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetLogger"/> class.
        /// </summary>
        /// <param name="type">The type to create a logger for.</param>
        public Log4NetLogger(Type type)
            : base(type)
        {
            this.log4NetLogger = LogManager.GetLogger(type);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Log4NetLogger"/> class.
        /// </summary>
        /// <param name="name">A custom name to use for the logger.  If null, the type's FullName will be used.</param>
        public Log4NetLogger(string name)
            : base(name)
        {
            this.log4NetLogger = LogManager.GetLogger(name);
        }

        /// <summary>
        /// Gets the name of the logger.
        /// </summary>
        /// <value>The name of the logger.</value>
        public override string Name
        {
            get
            {
                return this.log4NetLogger.Logger.Name;
            }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Debug severity should be logged.
        /// </summary>
        public override bool IsDebugEnabled
        {
            get { return this.log4NetLogger.IsDebugEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Info severity should be logged.
        /// </summary>
        public override bool IsInfoEnabled
        {
            get { return this.log4NetLogger.IsInfoEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Trace severity should be logged.
        /// </summary>
        public override bool IsTraceEnabled
        {
            get
            {
                return this.log4NetLogger.Logger.IsEnabledFor(Level.Trace);
            }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Warn severity should be logged.
        /// </summary>
        public override bool IsWarnEnabled
        {
            get { return this.log4NetLogger.IsWarnEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Error severity should be logged.
        /// </summary>
        public override bool IsErrorEnabled
        {
            get { return this.log4NetLogger.IsErrorEnabled; }
        }

        /// <summary>
        /// Gets a value indicating whether messages with Fatal severity should be logged.
        /// </summary>
        public override bool IsFatalEnabled
        {
            get { return this.log4NetLogger.IsFatalEnabled; }
        }

        /// <summary>
        /// Logs the specified message with Debug severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Debug(string message)
        {
            this.log4NetLogger.Debug(message);
        }

        /// <summary>
        /// Logs the specified exception with Debug severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public override void Debug(string message, Exception exception)
        {
            this.log4NetLogger.Debug(message, exception);
        }

        /// <summary>
        /// Logs the specified message with Info severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Info(string message)
        {
            this.log4NetLogger.Info(message);
        }

        /// <summary>
        /// Logs the specified exception with Info severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public override void Info(string message, Exception exception)
        {
            this.log4NetLogger.Info(message, exception);
        }

        /// <summary>
        /// Logs the specified message with Warn severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Warn(string message)
        {
            this.log4NetLogger.Warn(message);
        }

        /// <summary>
        /// Logs the specified message with Warn severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public override void Warn(string message, Exception exception)
        {
            this.log4NetLogger.Warn(message, exception);
        }

        /// <summary>
        /// Logs the specified message with Error severity.
        /// </summary>
        /// <param name="message">The message.</param>
        public override void Error(string message)
        {
            this.log4NetLogger.Error(message);
        }

        /// <summary>
        /// Logs the specified exception with Error severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        public override void Error(string message, Exception exception)
        {
            this.log4NetLogger.Error(message, exception);
        }

        public override void Debug(string message, string correlationId, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Debug;
            logData.Properties["correlationId"] = correlationId;

            SetEvent(logData);

        }

        public override void Debug(string message, double value, UnitType unitType, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Debug;
            logData.Properties["value"] = value;
            logData.Properties["unitType"] = unitType.ToString();

            SetEvent(logData);
        }

        public override void Debug(string message, double value, UnitType unitType, string correlationId, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Debug;
            logData.Properties["correlationId"] = correlationId;
            logData.Properties["value"] = value;
            logData.Properties["unitType"] = unitType.ToString();

            SetEvent(logData);
        }

        public override void Info(string message, string correlationId, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Info;
            logData.Properties["correlationId"] = correlationId;

            SetEvent(logData);
        }

        public override void Info(string message, double value, UnitType unitType, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Info;
            logData.Properties["value"] = value;
            logData.Properties["unitType"] = unitType.ToString();

            SetEvent(logData);
        }

        public override void Info(string message, double value, UnitType unitType, string correlationId, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Info;
            logData.Properties["correlationId"] = correlationId;
            logData.Properties["value"] = value;
            logData.Properties["unitType"] = unitType.ToString();

            SetEvent(logData);
        }

        public override void Warn(string message, string correlationId, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Warn;
            logData.Properties["correlationId"] = correlationId;

            SetEvent(logData);
        }

        public override void Warn(string message, double value, UnitType unitType, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Warn;
            logData.Properties["value"] = value;
            logData.Properties["unitType"] = unitType.ToString();

            SetEvent(logData);
        }

        public override void Warn(string message, double value, UnitType unitType, string correlationId, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Warn;
            logData.Properties["correlationId"] = correlationId;
            logData.Properties["value"] = value;
            logData.Properties["unitType"] = unitType.ToString();

            SetEvent(logData);
        }

        public override void Error(string message, string correlationId, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Error;
            logData.Properties["correlationId"] = correlationId;

            SetEvent(logData);
        }

        public override void Error(string message, double value, UnitType unitType, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Error;
            logData.Properties["value"] = value;
            logData.Properties["unitType"] = unitType.ToString();

            SetEvent(logData);
        }

        public override void Error(string message, double value, UnitType unitType, string correlationId, Exception exception = null)
        {
            var logData = CreateLogData(message, exception);
            logData.Level = Level.Error;
            logData.Properties["correlationId"] = correlationId;
            logData.Properties["value"] = value;
            logData.Properties["unitType"] = unitType.ToString();

            SetEvent(logData);
        }

        private static LoggingEventData CreateLogData(string message, Exception exception)
        {
            StackFrame frame = new StackFrame(2);
            var method = frame.GetMethod();
            var type = method.DeclaringType;

            var logData = new LoggingEventData();
            logData.TimeStamp = DateTime.UtcNow;
            logData.ThreadName = Thread.CurrentThread.Name;
            logData.Message = message;
            logData.LoggerName = type.Name;
            logData.Properties = new log4net.Util.PropertiesDictionary();
            logData.Properties["correlationId"] = null;
            logData.Properties["value"] = null;
            logData.Properties["unitType"] = null;

            if (exception != null)
                logData.ExceptionString = exception.Message;

            return logData;
        }

        private void SetEvent(LoggingEventData logData)
        {
            var logEvent = new LoggingEvent(logData);

            ((log4net.Core.LoggerWrapperImpl)(log4NetLogger)).Logger.Log(logEvent);
        }
    }
}
