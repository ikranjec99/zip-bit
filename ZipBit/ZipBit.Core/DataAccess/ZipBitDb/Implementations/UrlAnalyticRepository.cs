using Dapper;
using Microsoft.Data.SqlClient;
using ZipBit.Core.Configuration;
using ZipBit.Core.DataAccess.ZipBitDb.Interfaces;
using ZipBit.Core.DataAccess.ZipBitDb.Models;
using ZipBit.Core.DataAccess.ZipBitDb.Sql;

namespace ZipBit.Core.DataAccess.ZipBitDb.Implementations
{
    public class UrlAnalyticRepository : IUrlAnalyticRepository
    {
        private readonly string _connectionString;
        private readonly ISqlLogger _sqlLogger;

        public UrlAnalyticRepository(IConnectionStringConfiguration configuration, ISqlLogger sqlLogger)
        {
            _connectionString = configuration.ConnectionString;
            _sqlLogger = sqlLogger;
        }

        public async Task Add(long eventTypeId, long urlId)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            string sql = ZipBitDbLoader.Load("InsertUrlAnalyticEvent");

            var parameters = new InsertUrlAnalyticEventParameters
            {
                EventTypeId = eventTypeId,
                UrlId = urlId
            };

            using var _ = _sqlLogger.Log(sqlConnection, sql, parameters);
            await sqlConnection.ExecuteAsync(sql, parameters);
        }
    }
}
