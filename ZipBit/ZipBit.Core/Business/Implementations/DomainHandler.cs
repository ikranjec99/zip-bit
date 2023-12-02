using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using ZipBit.Core.Business.Constants;
using ZipBit.Core.Business.Exceptions;
using ZipBit.Core.Business.Interfaces;
using ZipBit.Core.Business.Models;
using ZipBit.Core.DataAccess.ZipBitDb.Interfaces;
using ZipBit.Core.Extensions;

namespace ZipBit.Core.Business.Implementations
{
    public class DomainHandler : IDomainHandler
    {
        private readonly ILogger _logger;
        private readonly IDomainRepository _domainRepository;

        public DomainHandler(ILogger<DomainHandler> logger, IDomainRepository domainRepository)
        {
            _logger = logger;
            _domainRepository = domainRepository;
        }

        public async Task<CreateDomainRequestResponse> CreateDomain(CreateDomainRequest request)
        {
            try
            {
                _logger.LogTryAddDomain(request.Name);

                long id = await _domainRepository.Add(request.Name);

                _logger.LogDomainAdded(id);

                return new CreateDomainRequestResponse { Id = id };
            }
            catch (SqlException e) when (e.Number == (int)SqlViolation.UniqueConstraintViolation)
            {
                _logger.LogDomainAlreadyExists(request.Name);
                throw new DomainAlreadyExistsException(request.Name);
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception e)
            {
                _logger.LogError(e, nameof(CreateDomain));
                throw;
            }
        }
    }
}
