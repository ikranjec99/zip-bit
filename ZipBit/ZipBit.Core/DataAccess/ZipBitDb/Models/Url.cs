namespace ZipBit.Core.DataAccess.ZipBitDb.Models
{
    public class Url
    {
        public DateTime Created { get; set; }

        public long Id { get; set; }

        public required string UrlOriginal { get; set; }

        public required string UrlShortened { get; set; }
    }
}
