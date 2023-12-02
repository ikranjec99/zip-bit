namespace ZipBit.Core.Business.Exceptions
{
    public class DomainAlreadyExistsException : BusinessException
    {
        public DomainAlreadyExistsException(string name) : base($"Domain with name {name} already exists.") { }
    }
}
