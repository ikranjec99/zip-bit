namespace ZipBit.API.Settings
{
    public class AppSettings
    {
        public required ConnectionStringElement ZipBitConnectionString { get; set; }

        public required SqlLoggerElement SqlLogger { get; set; }

        public required ZipBitElement ZipBit { get; set; }
    }
}
