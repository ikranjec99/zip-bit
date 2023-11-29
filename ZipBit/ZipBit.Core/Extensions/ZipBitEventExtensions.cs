namespace ZipBit.Core.Extensions
{
    public static class ZipBitEventExtensions
    {
        public static EventId ToEventId(this ZipBitEvent event) => new EventId((int) event, event.ToString());
    }
}
