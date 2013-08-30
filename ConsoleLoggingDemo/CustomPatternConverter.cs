using log4net.Core;
using log4net.Layout.Pattern;
using System.IO;

namespace ConsoleLoggingDemo
{
    public sealed class CustomPatternConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            // String to keep the custom message in
            string message = "";

            // If we've logged anything in Properties["correlationId"], append it to our message
            if (loggingEvent.Properties["correlationId"] != null)
                message = string.Format("CorrelationID: {0} ", loggingEvent.Properties["correlationId"].ToString());

            // If we've logged anything in Properties["value"], append it to our message
            if (loggingEvent.Properties["value"] != null)
                message = message + string.Format("Value: {0} ", System.Convert.ToDouble(loggingEvent.Properties["value"]));

            // If we've logged anything in Properties["unitType"], append it to our message
            if (loggingEvent.Properties["unitType"] != null)
                message = message + string.Format("UnitType: {0}", loggingEvent.Properties["unitType"].ToString());

            // If we've logged anything in Properties["exceptionMessage"], append it to our message
            if (loggingEvent.Properties["exceptionMessage"] != null)
                message = message + string.Format("Exception: {0}", loggingEvent.Properties["exceptionMessage"].ToString());

            // Write the message to the output
            writer.Write(message.Trim());
        }
    }
}
