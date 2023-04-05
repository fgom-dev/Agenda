using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories.UOW;
using Agenda.Domain.Services;
using Agenda.Shared.Errors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Agenda.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public UsuariosController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var token = Request.Headers.Authorization.ToString().Split()[1];

            var tokenDecoded = TokenService.Decode(token);

            var isAdmin = tokenDecoded.Payload["IsAdmin"].ToString() == "True";

            if (!isAdmin)
            {
                throw new CustomException(HttpStatusCode.Unauthorized, "Não autorizado!");
            }

            var usuarios = await _uow.UsuarioRepository.Get(parameters);

            var metadata = new
            {
                usuarios.PageSize,
                usuarios.TotalCount,
                usuarios.CurrentPage,
                usuarios.TotalPages,
                usuarios.HasNext,
                usuarios.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            return Ok(usuarios);
        }
    }
}
