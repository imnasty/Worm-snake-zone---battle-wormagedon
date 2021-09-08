using System;
using System.Runtime.Serialization;

namespace WebDAVClient.Helpers
{
    public class WebDAVConflictException : WebDAVException
    {
        public WebDAVConflictException()
        {
        }

        public WebDAVConflictException(string message) 
            : base(message)
        {}

        public WebDAVConflictException(string message, Exception innerException) 
            : base(message, innerException)
        {}

        public WebDAVConflictException(int httpCode, string message, Exception innerException) 
            : base(httpCode, message, innerException)
        {}

        public WebDAVConflictException(int httpCode, string message) 
            : base(httpCode, message)
        {}

        protected WebDAVConflictException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {}
    }
}