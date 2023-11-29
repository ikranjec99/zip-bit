using Serilog;
using ZipBit.API.Extensions;

namespace ZipBit.API.Helpers
{
    public static class LogHelper
    {
        public static void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
        {
            diagnosticContext.Set(nameof(httpContext.Connection.LocalIpAddress), httpContext.Connection.LocalIpAddress);
            diagnosticContext.Set(nameof(httpContext.Connection.RemoteIpAddress), httpContext.Connection.RemoteIpAddress);

            var request = httpContext.Request;

            diagnosticContext.Set(nameof(request.Host), request.Host);
            diagnosticContext.Set("RequestMethod", request.Method);
            diagnosticContext.Set("Resource", request.Path.Value);
            diagnosticContext.Set(nameof(request.Scheme), request.Scheme);
            diagnosticContext.Set(nameof(httpContext.Response.ContentType), httpContext.Response.ContentType);

            foreach (string headerKey in request.Headers.Keys.Where(key => !key.Contains("Cookie")
                                                                           && !key.Contains("credentials")
                                                                           && !key.Contains("Authorization")))

                diagnosticContext.Set(headerKey, request.Headers.GetValue(headerKey));

            foreach (var route in request.RouteValues) diagnosticContext.Set(route.Key, route.Value);

        }
    }
}
