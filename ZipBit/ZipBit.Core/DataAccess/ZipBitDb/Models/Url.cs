namespace ZipBit.Core.DataAccess.ZipBitDb.Models
{
    public class Url
    {
        public long Id { get; set; }

        public required string Code { get; set; }

        public DateTime Created { get; set; }

        public long DomainId { get; set; }

        public required string UrlOriginal { get; set; }
    }
}
