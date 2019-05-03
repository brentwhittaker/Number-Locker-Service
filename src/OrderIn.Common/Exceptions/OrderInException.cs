using System;

namespace OrderIn.Common.Exceptions
{
    public class OrderInException : Exception
    {
        public string Code { get; }
        public OrderInException()
        {
        }
        public OrderInException(string code)
        {
            Code = code;
        }
        public OrderInException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }
        public OrderInException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }
        public OrderInException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }
        public OrderInException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
