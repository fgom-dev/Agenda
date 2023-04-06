using Agenda.Domain.DTOs;
using Agenda.Domain.Models;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories.UOW;
using Agenda.Domain.Services;
using Agenda.Shared.Errors;
using Agenda.Shared.Services;
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var usuario = await _uow.UsuarioRepository.GetById(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                Email = usuarioDto.Email,
                PasswordHash = Crypt.GerarHash(usuarioDto.Password),
                PessoaId = usuarioDto.PessoaId,
                Pessoa = usuarioDto.Pessoa,
                IsAdmin = usuarioDto.IsAdmin,
            };

            _uow.UsuarioRepository.Add(usuario);
            await _uow.Commit();
            return Ok(TokenService.GeraToken(usuario));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UsuarioSaidaDto usuarioDto)
        {
            if (id != usuarioDto.Id)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Requisição inválida!");
            }

            var usuario = await _uow.UsuarioRepository.GetById(id);

            usuario.Email = usuarioDto.Email;
            usuario.PessoaId = usuarioDto.PessoaId;
            usuario.Pessoa = usuarioDto.Pessoa;
            usuario.IsAdmin = usuarioDto.IsAdmin;           

            _uow.UsuarioRepository.Update(usuario);
            await _uow.Commit();

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var usuario = await _uow.UsuarioRepository.GetById(id);
            _uow.UsuarioRepository.Delete(usuario);
            await _uow.Commit();
            return Ok(usuario);
        }
    }    
}
