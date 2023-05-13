using Agenda.Domain.DTOs.UsuarioDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories.UOW;
using Agenda.Domain.Services;
using Agenda.Shared.Errors;
using Agenda.Shared.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace Agenda.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public UsuariosController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
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

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var usuario = await _uow.UsuarioRepository.GetById(id);
            return Ok(usuario);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                Email = usuarioDto.Email,
                PasswordHash = Crypt.GerarHash(usuarioDto.Password),
                PessoaId = usuarioDto.PessoaId,
                IsAdmin = usuarioDto.IsAdmin,
            };

            _uow.UsuarioRepository.Add(usuario);
            await _uow.Commit();
            return Ok(TokenService.GeraToken(usuario));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> VincularPessoa(int id, [FromBody] UsuarioVinculoDto usuarioDto)
        {
            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).Select(x => x.Value).ToList()[0];
            var isAdmin = User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList().Exists(x => x == "Admin");

            if (id != usuarioDto.IdUsuario)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Requisição inválida!");
            }

            var usuario = await _uow.UsuarioRepository.GetById(id);

            if (usuario.Email != email && !isAdmin)
            {
                throw new CustomException(HttpStatusCode.Unauthorized, "Não Autorizado!");
            }

            var pessoa = await _uow.PessoaRepository.GetById(usuarioDto.PessoaId);

            if (pessoa == null)
            {
                throw new CustomException(HttpStatusCode.NotFound, "Pessoa não encontrada!");
            }

            usuario.PessoaId = usuarioDto.PessoaId;

            _uow.UsuarioRepository.Update(usuario);
            await _uow.Commit();

            return Ok(usuario);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await _uow.UsuarioRepository.GetById(id);
            _uow.UsuarioRepository.Delete(usuario);
            await _uow.Commit();
            return Ok(usuario);
        }
    }
}
