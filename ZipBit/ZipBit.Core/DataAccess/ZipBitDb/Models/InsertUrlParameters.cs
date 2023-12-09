namespace ZipBit.Core.DataAccess.ZipBitDb.Models
{
    public class InsertUrlParameters
    {
        public required string Code { get; set; }

        public long DomainId { get; set; }

        public required string UrlOriginal { get; set; }
    }
}
