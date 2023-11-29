using ZipBit.Core.Configuration;

namespace ZipBit.API.Settings
{
    public class ConnectionStringElement : IConnectionStringConfiguration
    {
        public required string ConnectionString { get; init; }
    }
}
