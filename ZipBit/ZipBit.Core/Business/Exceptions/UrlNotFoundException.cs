namespace ZipBit.Core.Business.Exceptions
{
    public class UrlNotFoundException : BusinessException
    {
        public UrlNotFoundException(string code) : base($"Url was not found by code {code}.") { }
    }
}
