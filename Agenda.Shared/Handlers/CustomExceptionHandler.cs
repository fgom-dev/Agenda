using Agenda.Shared.Errors;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Agenda.Shared.Handlers
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;
        public CustomExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, CustomException exception)
        {
            // else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            // else if (exception is MyException)             code = HttpStatusCode.BadRequest;

            var result = JsonSerializer.Serialize(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.StatusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
