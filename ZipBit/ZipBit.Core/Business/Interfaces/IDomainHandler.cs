using ZipBit.Core.Business.Models;

namespace ZipBit.Core.Business.Interfaces
{
    public interface IDomainHandler
    {
        /// <summary>
        /// Create new domain
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CreateDomainRequestResponse> CreateDomain(CreateDomainRequest request);
    }
}
