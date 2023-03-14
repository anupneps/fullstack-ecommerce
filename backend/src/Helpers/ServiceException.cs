using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace backend.src.Helpers
{
    public class ServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public override string Message { get; } 

        public ServiceException (HttpStatusCode statusCode, string message )
        {
            StatusCode = statusCode;
            Message = message;
        }

        public static ServiceException NotFound(string message = "Id is not found")
        {
            return new ServiceException(HttpStatusCode.NotFound, message);
        }
    }
}