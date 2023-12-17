using ZipBit.Core.DataAccess.ZipBitDb.Models;

namespace ZipBit.Core.DataAccess.ZipBitDb.Interfaces
{
    public interface IDomainRepository
    {
        /// <summary>
        /// Get Domain entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns domain by id</returns>
        Task<Domain> GetById(long id);
    }
}
