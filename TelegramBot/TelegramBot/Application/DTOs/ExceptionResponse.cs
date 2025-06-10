using System.Net;

namespace TelegramBot.Application.DTOs
{
    public class ExceptionResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
