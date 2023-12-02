using Dapper;
using Microsoft.Data.SqlClient;
using ZipBit.Core.Configuration;
using ZipBit.Core.DataAccess.ZipBitDb.Interfaces;
using ZipBit.Core.DataAccess.ZipBitDb.Models;
using ZipBit.Core.DataAccess.ZipBitDb.Sql;

namespace ZipBit.Core.DataAccess.ZipBitDb.Implementations
{
    public class UrlRepository : IUrlRepository
    {
        private readonly string _connectionString;
        private readonly ISqlLogger _sqlLogger;

        public UrlRepository(IConnectionStringConfiguration configuration, ISqlLogger sqlLogger)
        {
            _connectionString = configuration.ConnectionString;
            _sqlLogger = sqlLogger;
        }

        public async Task<long> Add(string code, long domainId, string urlOriginal)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            string sql = ZipBitDbLoader.Load("InsertUrl");

            var parameters = new InsertUrlParameters
            {
                Code = code,
                DomainId = domainId,
                UrlOriginal = urlOriginal
            };

            using var _ = _sqlLogger.Log(sqlConnection, sql, parameters);
            return await sqlConnection.ExecuteScalarAsync<long>(sql, parameters);
        }

        public async Task<Url> GetByCode(string code)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            string sql = ZipBitDbLoader.Load("SelectUrlByCode");

            var parameters = new SelectUrlByCodeParameters { Code = code };

            using var _ = _sqlLogger.Log(sqlConnection, sql, parameters);
            return await sqlConnection.QuerySingleOrDefaultAsync<Url>(sql, parameters);
        }

        public async Task<Url> GetById(long id)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            string sql = ZipBitDbLoader.Load("SelectUrlById");

            var parameters = new SelectUrlByIdParameters { Id = id };

            using var _ = _sqlLogger.Log(sqlConnection, sql, parameters);
            return await sqlConnection.QuerySingleOrDefaultAsync<Url>(sql, parameters);
        }
    }
}
