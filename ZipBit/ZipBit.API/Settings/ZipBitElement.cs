using ZipBit.Core.Configuration;

namespace ZipBit.API.Settings
{
    public class ZipBitElement : IZipBitConfiguration
    {
        public long DefaultDomainId { get; init; }
    }
}
