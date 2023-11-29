using ZipBit.Core.Extensions;

namespace ZipBit.Core.DataAccess.ZipBitDb.Sql
{
    public static class ZipBitDbLoader
    {
        public static string Load(string scriptName)
        {
            string resourceName = $"{nameof(ZipBit)}.{nameof(Core)}.{nameof(DataAccess)}.{nameof(ZipBitDb)}.{nameof(Sql)}.{scriptName}.sql";
            return typeof(ZipBitDbLoader).Assembly.ReadResourceText(resourceName).Insert(0, $"--{scriptName}\n");
        }
    }
}
