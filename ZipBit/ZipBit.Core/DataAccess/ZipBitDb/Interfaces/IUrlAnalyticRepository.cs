namespace ZipBit.Core.DataAccess.ZipBitDb.Interfaces
{
    public interface IUrlAnalyticRepository
    {
        /// <summary>
        /// Create url analytics event
        /// </summary>
        /// <param name="eventTypeId">Generated code of shortened URL</param>
        /// <param name="urlId">Id of supported domain</param>
        Task Add(long eventTypeId, long urlId);
    }
}
