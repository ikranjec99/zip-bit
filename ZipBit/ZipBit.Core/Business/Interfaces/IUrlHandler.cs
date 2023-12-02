using ZipBit.Core.Business.Models;

namespace ZipBit.Core.Business.Interfaces
{
    public interface IUrlHandler
    {
        /// <summary>
        /// Create shortened url
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateShortenedUrlResponse> CreateShortenedUrl(CreateShortenedUrlRequest request);

        /// <summary>
        /// Get original url by code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UrlResponse> GetUrlByCode(GetUrlByCodeRequest request);
    }
}
