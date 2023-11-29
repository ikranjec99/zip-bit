namespace ZipBit.Core.DataAccess.ZipBitDb.Models
{
    public class InsertUrlParameters
    {
        public required string UrlOriginal { get; set; }

        public required string UrlShortened { get; set; }
    }
}
