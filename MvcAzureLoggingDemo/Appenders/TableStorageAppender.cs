using log4net.Appender;
using log4net.Core;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;
using MvcAzureLoggingDemo.Models;
using System;

namespace MvcAzureLoggingDemo.Appenders
{
    public class TableStorageAppender : AppenderSkeleton
    {
        private string _connectionStringKey = "UseDevelopmentStorage=true";
        private string _tableName = "LogEntities";

        private TableServiceContext _dataContext;
        private CloudTable _table;

        public string ConnectionStringKey
        {
            get { return _connectionStringKey; }
            set { _connectionStringKey = value; }
        }

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public override void ActivateOptions()
        {
            base.ActivateOptions();

            CloudStorageAccount account = CloudStorageAccount.Parse(_connectionStringKey);
            CloudTableClient tableClient = account.CreateCloudTableClient();
            _table = tableClient.GetTableReference(TableName);
            _table.CreateIfNotExists();
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            var entity = new LogEventAzure();

            try
            {
                entity.Message = loggingEvent.RenderedMessage;
                entity.Level = loggingEvent.Level.Name;
                entity.LoggerName = loggingEvent.LoggerName;
                entity.ThreadName = loggingEvent.ThreadName;
                entity.CorrelationId = null;
                entity.Value = 0.0;
                entity.UnitType = null;
                entity.Exception = null;

                if (!string.IsNullOrEmpty(loggingEvent.GetExceptionString()))
                    entity.Exception = loggingEvent.ExceptionObject.Message;

                if (loggingEvent.Properties["correlationId"] != null)
                    entity.CorrelationId = loggingEvent.Properties["correlationId"].ToString();

                if (loggingEvent.Properties["value"] != null)
                    entity.Value = Convert.ToDouble(loggingEvent.Properties["value"]);

                if (loggingEvent.Properties["unitType"] != null)
                    entity.UnitType = loggingEvent.Properties["unitType"].ToString();

                TableOperation insertOperation = TableOperation.Insert(entity);
                _table.Execute(insertOperation);
            }
            catch (Exception e)
            {
                ErrorHandler.Error("Could not write log entry", e);
            }

        }
    }
}