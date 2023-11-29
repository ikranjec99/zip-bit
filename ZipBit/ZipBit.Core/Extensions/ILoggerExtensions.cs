using Microsoft.Extensions.Logging;

namespace ZipBit.Core.Extensions
{
    public static class ILoggerExtensions
    {
        public static void LogError(this ILogger logger, string methodName, Exception e)
            => logger.LogError(e, "{MethodName} failed: {Message}", methodName, e.Message);
    }
}
