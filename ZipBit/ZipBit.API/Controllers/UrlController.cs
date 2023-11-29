using Microsoft.AspNetCore.Mvc;
using ZipBit.Core.Business.Interfaces;
using ZipBit.Core.Business.Models;

namespace ZipBit.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("zipbit/{version:apiVersion}/url")]
    public sealed class UrlController : ControllerBase
    {
        private readonly IUrlHandler _urlHandler;

        public UrlController(IUrlHandler urlHandler)
        {
            _urlHandler = urlHandler;
        }

        /// <summary>
        /// Shorten an URL
        /// </summary>
        /// <returns>Returns URL shortening result</returns>
        [HttpPost]
        public Task<CreateShortenedUrlResponse> PostUrl([FromBody] CreateShortenedUrlRequest request) =>
            _urlHandler.CreateShortenedUrl(request);
    }
}
