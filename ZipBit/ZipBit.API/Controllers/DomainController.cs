using Microsoft.AspNetCore.Mvc;
using ZipBit.Core.Business.Interfaces;
using ZipBit.Core.Business.Models;

namespace ZipBit.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/zipbit/{version:apiVersion}/domain")]
    public sealed class DomainController : ControllerBase
    {
        private readonly IDomainHandler _domainHandler;

        public DomainController(IDomainHandler domainHandler)
        {
            _domainHandler = domainHandler;
        }

        /// <summary>
        /// Add new domain
        /// </summary>
        /// <returns>Create new domain for separate shortening service</returns>
        [HttpPost]
        public async Task<CreateDomainRequestResponse> PostDomain([FromBody] CreateDomainRequest request)
            => await _domainHandler.CreateDomain(request);
    }
}
