using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace MvcAzureLoggingDemo.Models
{
    public sealed class LogEventAzure : TableEntity
    {
        public LogEventAzure()
        {
            var now = DateTime.UtcNow;
            this.PartitionKey = string.Format("{0:yyyy-MM-dd}", now);
            this.RowKey = string.Format("{0:HH:mm:ss} - {1}", now, Guid.NewGuid());
        }

        public string ThreadName { get; set; }
        public string LoggerName { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string CorrelationId { get; set; }
        public double Value { get; set; }
        public string UnitType { get; set; }
        public string Exception { get; set; }
    }
}