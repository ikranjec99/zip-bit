using Microsoft.Extensions.Logging;

namespace ZipBit.Core.Extensions
{
    public static class ILoggerExtensions
    {
        public static void LogError(this ILogger logger, string methodName, Exception e)
            => logger.LogError(e, "{MethodName} failed: {Message}", methodName, e.Message);

        public static void LogSqlConnection(this ILogger logger, object scriptName, object executionTime, object connectionTime, object networkServerTime, object parameters)
            => logger.LogInformation(
                "ScriptName: {ScriptName}, Execution time: {ExecutionTime}ms, ConnectionTime: {ConnectionTime}ms, NetworkServerTime: {NetworkServerTime}ms, Parameters: {@Parameters}",
                scriptName,
                executionTime,
                connectionTime,
                networkServerTime,
                parameters
            );

        public static void LogTryShortenUrl(this ILogger logger, string url)
            => logger.LogInformation("Trying to shorten url {Url}", url);

        public static void LogUrlShortened(this ILogger logger, string originalUrl, string shortenedUrl)
            => logger.LogInformation("Url {OriginalUrl} shortened successfully to {ShortenedUrl}", originalUrl, shortenedUrl);
    }
}
