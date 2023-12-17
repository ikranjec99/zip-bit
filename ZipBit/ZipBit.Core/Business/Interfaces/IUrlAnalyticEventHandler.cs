using ZipBit.Core.Business.Models;

namespace ZipBit.Core.Business.Interfaces
{
    public interface IUrlAnalyticEventHandler
    {
        /// <summary>
        /// Add new url event to analytics table
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task AddUrlAnalyticEvent(long eventTypeId, long urlId);
    }
}
