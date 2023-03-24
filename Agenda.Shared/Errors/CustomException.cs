using System.Net;

namespace Agenda.Shared.Errors
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public CustomException(HttpStatusCode statusCode, string? message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
