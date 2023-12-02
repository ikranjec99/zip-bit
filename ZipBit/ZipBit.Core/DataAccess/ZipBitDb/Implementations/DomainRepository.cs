using Dapper;
using Microsoft.Data.SqlClient;
using ZipBit.Core.Configuration;
using ZipBit.Core.DataAccess.ZipBitDb.Interfaces;
using ZipBit.Core.DataAccess.ZipBitDb.Models;
using ZipBit.Core.DataAccess.ZipBitDb.Sql;

namespace ZipBit.Core.DataAccess.ZipBitDb.Implementations
{
    public class DomainRepository : IDomainRepository
    {
        private readonly string _connectionString;
        private readonly ISqlLogger _sqlLogger;

        public DomainRepository(IConnectionStringConfiguration configuration, ISqlLogger sqlLogger)
        {
            _connectionString = configuration.ConnectionString;
            _sqlLogger = sqlLogger;
        }

        public async Task<long> Add(string name)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            string sql = ZipBitDbLoader.Load("InsertDomain");

            var parameters = new InsertDomainParameters { Name = name };

            using var _ = _sqlLogger.Log(sqlConnection, sql, parameters);
            return await sqlConnection.ExecuteScalarAsync<long>(sql, parameters);
        }

        public async Task<Domain> GetById(long id)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            string sql = ZipBitDbLoader.Load("SelectDomainById");

            var parameters = new SelectDomainByIdParameters { Id = id };

            using var _ = _sqlLogger.Log(sqlConnection, sql, parameters);
            return await sqlConnection.QuerySingleOrDefaultAsync<Domain>(sql, parameters);
        }
    }
}
