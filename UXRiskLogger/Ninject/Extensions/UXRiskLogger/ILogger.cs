using System;

namespace Ninject.Extensions.UXRiskLogger
{
    public interface ILogger
    {
        /// <summary>
        /// Gets the type associated with the logger.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Gets the name of the logger.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Debug severity should be logged.
        /// </summary>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Info severity should be logged.
        /// </summary>
        bool IsInfoEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Trace severity should be logged.
        /// </summary>
        bool IsTraceEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Warn severity should be logged.
        /// </summary>
        bool IsWarnEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Error severity should be logged.
        /// </summary>
        bool IsErrorEnabled { get; }

        /// <summary>
        /// Gets a value indicating whether messages with Fatal severity should be logged.
        /// </summary>
        bool IsFatalEnabled { get; }

        /// <summary>
        /// Logs the specified message with Debug severity.
        /// </summary>
        /// <param name="message">The message.</param>
        void Debug(string message);

        /// <summary>
        /// Logs the specified exception with Debug severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        void Debug(string message, Exception exception);

        /// <summary>
        /// Logs the specified message with Info severity.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(string message);

        /// <summary>
        /// Logs the specified exception with Info severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        void Info(string message, Exception exception);

        /// <summary>
        /// Logs the specified message with Warn severity.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warn(string message);

        /// <summary>
        /// Logs the specified message with Warn severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        void Warn(string message, Exception exception);

        /// <summary>
        /// Logs the specified message with Error severity.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);

        /// <summary>
        /// Logs the specified exception with Error severity.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception to log.</param>
        void Error(string message, Exception exception);

        // Added for UXRisk
        void Debug(string message, string correlationId, Exception exception = null);
        void Debug(string message, double value, UnitType unitType, Exception exception = null);
        void Debug(string message, double value, UnitType unitType, string correlationId, Exception exception = null);

        void Info(string message, string correlationId, Exception exception = null);
        void Info(string message, double value, UnitType unitType, Exception exception = null);
        void Info(string message, double value, UnitType unitType, string correlationId, Exception exception = null);

        void Warn(string message, string correlationId, Exception exception = null);
        void Warn(string message, double value, UnitType unitType, Exception exception = null);
        void Warn(string message, double value, UnitType unitType, string correlationId, Exception exception = null);

        void Error(string message, string correlationId, Exception exception = null);
        void Error(string message, double value, UnitType unitType, Exception exception = null);
        void Error(string message, double value, UnitType unitType, string correlationId, Exception exception = null);
    }
}
