using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using ZipBit.Core.Business.Constants;
using ZipBit.Core.Business.Interfaces;
using ZipBit.Core.Business.Models;
using ZipBit.Core.Configuration;
using ZipBit.Core.DataAccess.ZipBitDb.Interfaces;
using ZipBit.Core.Extensions;

namespace ZipBit.Core.Business.Implementations
{
    public class UrlHandler : IUrlHandler
    {
        private readonly ILogger _logger;
        private readonly IUrlRepository _urlRepository;
        private readonly IZipBitConfiguration _zipBitConfiguration;

        public UrlHandler(ILogger<UrlHandler> logger, IUrlRepository urlRepository, IZipBitConfiguration zipBitConfiguration)
        {
            _logger = logger;
            _urlRepository = urlRepository;
            _zipBitConfiguration = zipBitConfiguration;
        }

        public async Task<CreateShortenedUrlResponse> CreateShortenedUrl(CreateShortenedUrlRequest request)
        {
            try
            {
                _logger.LogTryShortenUrl(request.UrlOriginal);
                return await AddShortenedUrl(request);
            }
            catch (SqlException e) when (e.Number == (int)SqlViolation.UniqueConstraintViolation)
            {
                _logger.LogShortenUrlUniqueConstraintViolation(request.UrlOriginal);
                return await AddShortenedUrl(request);
            }
            catch (Exception e)
            {
                _logger.LogError(e, nameof(CreateShortenedUrl));
                throw;
            }
        }

        private async Task<CreateShortenedUrlResponse> AddShortenedUrl(CreateShortenedUrlRequest request)
        {
            try
            {
                string urlShortened = GenerateShortenedUrl();
                long id = await _urlRepository.Add(request.UrlOriginal, urlShortened);

                var createdShortenedUrl = await _urlRepository.GetById(id);
                _logger.LogUrlShortened(request.UrlOriginal, createdShortenedUrl.UrlShortened);

                return new CreateShortenedUrlResponse { UrlShortened = createdShortenedUrl.UrlShortened };
            }
            catch (Exception e)
            {
                _logger.LogError(e, nameof(AddShortenedUrl));
                throw;
            }
        }

        private string GenerateShortenedUrl() => $"{_zipBitConfiguration.Domain}/{Guid.NewGuid().ToString("N").Substring(0, 10)}";
    }
}
