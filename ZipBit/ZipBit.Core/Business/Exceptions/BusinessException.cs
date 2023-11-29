using System.Runtime.Serialization;

namespace ZipBit.Core.Business.Exceptions
{
    public class BusinessException : Exception
    {
        protected BusinessException() : base() { }

        protected BusinessException(string message) : base(message) { }

        protected BusinessException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
