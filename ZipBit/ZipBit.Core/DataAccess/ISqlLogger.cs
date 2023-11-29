using Microsoft.Data.SqlClient;

namespace ZipBit.Core.DataAccess
{
    public interface ISqlLogger
    {
        SqlLog Log(SqlConnection sqlConnection, string sql, object parameters);
    }
}
