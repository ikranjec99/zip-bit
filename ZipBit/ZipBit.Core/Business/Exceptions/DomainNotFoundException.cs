namespace ZipBit.Core.Business.Exceptions
{
    public class DomainNotFoundException : BusinessException
    {
        public DomainNotFoundException(long id) : base($"Domain with id {id} was not found.") { }
    }
}
