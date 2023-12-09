using ZipBit.Core.DataAccess.ZipBitDb.Models;

namespace ZipBit.Core.DataAccess.ZipBitDb.Interfaces
{
    public interface IUrlRepository
    {
        /// <summary>
        /// Create shortened url
        /// </summary>
        /// <param name="code">Generated code of shortened URL</param>
        /// <param name="domainId">Id of supported domain</param>
        /// <param name="urlOriginal">URL that is being shortened</param>
        /// <returns>Returns id of created shortened url</returns>
        Task<long> Add(string code, long domainId, string urlOriginal);

        /// <summary>
        /// Get Url entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns url entity by id</returns>
        Task<Url> GetById(long id);

        /// <summary>
        /// Get Url entity by code
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns url entity by id</returns>
        Task<Url> GetByCode(string code);
    }
}
