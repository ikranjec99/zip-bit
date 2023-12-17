namespace ZipBit.Core.DataAccess.ZipBitDb.Models
{
    public class UrlAnalytic
    {
        public long Id { get; set; }

        public DateTime Created {  get; set; }

        public long EventType { get; set; }

        public long UrlId { get; set; }
    }
}
