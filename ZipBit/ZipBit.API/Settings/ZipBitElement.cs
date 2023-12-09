using ZipBit.Core.Configuration;

namespace ZipBit.API.Settings
{
    public class ZipBitElement : IZipBitConfiguration
    {
        public required string DefaultDomain { get; init; }
    }
}
