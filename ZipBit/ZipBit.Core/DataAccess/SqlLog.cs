using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using ZipBit.Core.Configuration;
using ZipBit.Core.Extensions;

namespace ZipBit.Core.DataAccess
{
    public sealed class SqlLog : IDisposable
    {
        private const string ConnectionTime = "ConnectionTime";
        private const string ExecutionTime = "ExecutionTime";
        private const string NetworkServerTime = "NetworkServerTime";

        private readonly ILogger _logger;
        private readonly ISqlLoggerConfiguration _sqlLoggerConfiguration;
        private readonly SqlConnection _sqlConnection;
        private readonly string _sql;
        private readonly object _parameters;

        public SqlLog(ISqlLoggerConfiguration sqlLoggerConfiguration, ILogger logger, SqlConnection sqlConnection, string sql, object parameters)
        {
            _sqlLoggerConfiguration = sqlLoggerConfiguration;
            if (!_sqlLoggerConfiguration.Enabled)
                return;

            _logger = logger;
            _sqlConnection = sqlConnection;
            _sql = sql;
            _parameters = parameters;
        }

        public void Dispose()
        {
            if (!_sqlLoggerConfiguration.Enabled)
                return;

            var statistics = _sqlConnection.RetrieveStatistics();
            
            _logger.LogSqlConnection(
                _sql.FirstLine().Replace("--", string.Empty),
                statistics[ExecutionTime],
                statistics[ConnectionTime],
                statistics[NetworkServerTime],
                _parameters
            );
            _sqlConnection.ResetStatistics();
        }
    }
}
