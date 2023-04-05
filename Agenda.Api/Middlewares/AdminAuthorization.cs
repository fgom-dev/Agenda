using Agenda.Domain.Services;
using Agenda.Shared.Errors;
using System.Net;

namespace Agenda.Api.Middlewares
{
    public class AdminAuthorization
    {
        private readonly RequestDelegate _next;
        public AdminAuthorization(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers.Authorization.ToString().Split()[1];

            var tokenDecoded = TokenService.Decode(token);

            var isAdmin = tokenDecoded.Payload["IsAdmin"].ToString() == "True";
            
            if (!isAdmin)
            {
                throw new CustomException(HttpStatusCode.Unauthorized, "Não autorizado!");
            }

            await _next(context);
        }
    }
}
