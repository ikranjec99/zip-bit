using Microsoft.Extensions.Logging;
using ZipBit.Core.Business.Exceptions;
using ZipBit.Core.Business.Interfaces;
using ZipBit.Core.DataAccess.ZipBitDb.Interfaces;
using ZipBit.Core.Extensions;

namespace ZipBit.Core.Business.Implementations
{
    public class UrlAnalyticEventHandler : IUrlAnalyticEventHandler
    {
        private readonly ILogger _logger;
        private readonly IUrlAnalyticRepository _urlAnalyticRepository;

        public UrlAnalyticEventHandler(ILogger<UrlAnalyticEventHandler> logger, IUrlAnalyticRepository urlAnalyticRepository)
        {
            _logger = logger;
            _urlAnalyticRepository = urlAnalyticRepository;
        }

        public async Task AddUrlAnalyticEvent(long eventTypeId, long urlId)
        {
            try
            {
                await _urlAnalyticRepository.Add(eventTypeId, urlId);
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
    }
}
