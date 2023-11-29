using Microsoft.Extensions.Logging;
using ZipBit.Core.Constants;

namespace ZipBit.Core.Extensions
{
    public static class ZipBitEventExtensions
    {
        public static EventId ToEventId(this ZipBitEvent zipBitEvent) => new EventId((int)zipBitEvent, zipBitEvent.ToString());
    }
}
