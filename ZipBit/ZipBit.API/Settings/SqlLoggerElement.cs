using System.ComponentModel.DataAnnotations;
using ZipBit.Core.Configuration;

namespace ZipBit.API.Settings
{
    public class SqlLoggerElement : ISqlLoggerConfiguration
    {
        [Required]
        public bool Enabled { get; set; }
    }
}
