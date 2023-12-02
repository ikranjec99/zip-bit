namespace ZipBit.Core.DataAccess.ZipBitDb.Models
{
    public class Domain
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public DateTime Created {  get; set; }
    }
}
