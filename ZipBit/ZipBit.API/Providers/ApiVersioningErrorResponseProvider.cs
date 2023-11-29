using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace ZipBit.API.Providers
{
    public class ApiVersioningErrorResponseProvider : DefaultErrorResponseProvider
    {
        public override IActionResult CreateResponse(ErrorResponseContext context)
        {
            switch (context.ErrorCode)
            {
                case "UnsupportedApiVersion":
                    context = new ErrorResponseContext(context.Request, context.StatusCode, context.ErrorCode,
                        "Selected API version is not supported", context.MessageDetail);
                    break;
            }

            return base.CreateResponse(context);
        }
    }
}
