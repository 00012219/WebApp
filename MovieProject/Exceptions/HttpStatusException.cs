using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MovieProject.Exceptions
{
    public class HttpStatusException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public HttpStatusException(HttpStatusCode statusCode, string message, Exception innerException = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }

}
