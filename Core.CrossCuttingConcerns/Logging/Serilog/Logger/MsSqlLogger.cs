using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Logger
{
    public class MsSqlLogger:LoggerServiceBase
    {
        private IConfiguration Configuration;

        public MsSqlLogger(IConfiguration configuration)
        {
            Configuration = configuration;

            MsSqlConfiguration msSqlConfiguration = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration")
                .Get<MsSqlConfiguration>() ??
                throw new Exception(SeriLogMessages.NullOptionsMessage);

            var sinksOpts = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = false };

            var columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Message);
            columnOpts.Store.Remove(StandardColumn.Properties);

            var seriLogConfig = new LoggerConfiguration()
                .WriteTo.MSSqlServer(connectionString: msSqlConfiguration.ConnectionString,
                sinkOptions: sinksOpts, columnOptions: columnOpts)
                .CreateLogger();
            Logger = seriLogConfig;
                
        }
    }
}
