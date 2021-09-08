using System;
using System.Runtime.Serialization;

namespace WebDAVClient.Helpers
{
    public class WebDAVException : Exception
    {
        public int HttpCode { get; }

        public WebDAVException()
        {
        }

        public WebDAVException(string message) 
            : base(message)
        {}

        public WebDAVException(string message, Exception innerException) 
            : base(message, innerException)
        {}

        public WebDAVException(int httpCode, string message, Exception innerException) 
            : base(message, innerException)
        {
            HttpCode = httpCode;
        }

        public WebDAVException(int httpCode, string message) 
            : base(message)
        {
            HttpCode = httpCode;
        }

        protected WebDAVException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {}

        public override string ToString()
        {
            var s = string.Format("HttpStatusCode: {0}", HttpCode);
            s += Environment.NewLine + string.Format("Message: {0}", Message);
            s += Environment.NewLine + base.ToString();

            return s;
        }
    }
}