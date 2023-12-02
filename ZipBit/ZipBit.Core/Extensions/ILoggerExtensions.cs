using Microsoft.Extensions.Logging;

namespace ZipBit.Core.Extensions
{
    public static class ILoggerExtensions
    {
        public static void LogDomainAdded(this ILogger logger, long id)
            => logger.LogInformation($"Domain with id {id} added.");

        public static void LogDomainAlreadyExists(this ILogger logger, string name)
            => logger.LogError($"Domain {name} already exists.");

        public static void LogDomainNotFound(this ILogger logger, long id)
            => logger.LogError($"Domain with id {id} not found.");

        public static void LogError(this ILogger logger, string methodName, Exception e)
            => logger.LogError(e, "{MethodName} failed: {Message}", methodName, e.Message);

        public static void LogUrlNotFoundByCode(this ILogger logger, string code)
            => logger.LogError($"Url with code {code} not found.");

        public static void LogTryAddDomain(this ILogger logger, string name)
            => logger.LogInformation($"Trying to add new domain {name}");

        public static void LogTryUrlShortening(this ILogger logger, string code, string url, long domainId)
            => logger.LogInformation($"Trying to shorten url {url} with domain id {domainId} and generated code {code}.");

        public static void LogUrlShortened(this ILogger logger, string originalUrl, string shortenedUrl)
            => logger.LogInformation($"Url {originalUrl} successfully shortened to {shortenedUrl}");

        public static void LogSqlConnection(this ILogger logger, object scriptName, object executionTime, object connectionTime, object networkServerTime, object parameters)
            => logger.LogInformation(
                "ScriptName: {ScriptName}, Execution time: {ExecutionTime}ms, ConnectionTime: {ConnectionTime}ms, NetworkServerTime: {NetworkServerTime}ms, Parameters: {@Parameters}",
                scriptName,
                executionTime,
                connectionTime,
                networkServerTime,
                parameters
            );
    }
}
