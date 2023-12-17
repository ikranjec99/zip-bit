using Microsoft.Extensions.Logging;
using ZipBit.Core.Business.Exceptions;
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
        private readonly IDomainRepository _domainRepository;
        private readonly IUrlRepository _urlRepository;
        private readonly IZipBitConfiguration _zipBitConfiguration;

        public UrlHandler(ILogger<UrlHandler> logger, IDomainRepository domainRepository, IUrlRepository urlRepository, IZipBitConfiguration zipBitConfiguration)
        {
            _logger = logger;
            _domainRepository = domainRepository;
            _urlRepository = urlRepository;
            _zipBitConfiguration = zipBitConfiguration;
        }

        public async Task<CreateShortenedUrlResponse> CreateShortenedUrl(CreateShortenedUrlRequest request)
        {
            try
            {
                string code = GenerateCode();
                long defaultDomainId = _zipBitConfiguration.DefaultDomainId;
                _logger.LogTryShortenUrl(code, request.Url, defaultDomainId);

                var domain = await _domainRepository.GetById(defaultDomainId);

                if (domain is null)
                {
                    _logger.LogDomainNotFound(defaultDomainId);
                    throw new DomainNotFoundException(defaultDomainId);
                }

                long urlId = await _urlRepository.Add(code, defaultDomainId, request.Url);
                var url = await _urlRepository.GetById(urlId);

                string urlShortened = $"{domain.Name}/{url.Code}";
                _logger.LogUrlShortened(request.Url, urlShortened);

                return new CreateShortenedUrlResponse { UrlShortened = urlShortened };
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                throw;
            }
        }

        public async Task<UrlResponse> GetUrlByCode(GetUrlByCodeRequest request)
        {
            try
            {
                var url = await _urlRepository.GetByCode(request.Code);

                if (url is null)
                {
                    _logger.LogUrlNotFound(request.Code);
                    throw new UrlNotFoundException(request.Code);
                }

                return new UrlResponse { Url = url.UrlOriginal };
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                throw;
            }
        }

        private string GenerateCode() => Guid.NewGuid().ToString("N").Substring(0, 10);
    }
}
