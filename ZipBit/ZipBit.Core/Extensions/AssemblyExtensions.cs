using System.Reflection;

namespace ZipBit.Core.Extensions
{
    public static class AssemblyExtensions
    {
        public static string ReadResourceText(this Assembly assembly, string resource)
        {
            using var stream = assembly.GetManifestResourceStream(resource);
            return new StreamReader(stream).ReadToEnd();
        }
    }
}
