using ZipBit.Core.Configuration;

namespace ZipBit.API.Settings
{
    public class ZipBitElement : IZipBitConfiguration
    {
        public required string Domain { get; init; }
    }
}
