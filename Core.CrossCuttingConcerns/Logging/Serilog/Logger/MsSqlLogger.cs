using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Logger
{
    public class MsSqlLogger : LoggerServiceBase
    {
        private IConfiguration Configuration;

        public MsSqlLogger(IConfiguration configuration)
        {
            Configuration = configuration;

            MsSqlConfiguration msSqlConfiguration = Configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration")
                .Get<MsSqlConfiguration>() ??
                throw new Exception(SeriLogMessages.NullOptionsMessage);

            var sinksOpts = new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = false };

            var columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Message);
            columnOpts.Store.Remove(StandardColumn.Properties);

            Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(connectionString: msSqlConfiguration.ConnectionString,
                sinkOptions: sinksOpts, columnOptions: columnOpts)
                .CreateLogger();

        }
    }
}

