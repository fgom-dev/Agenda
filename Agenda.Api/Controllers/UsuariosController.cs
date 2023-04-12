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
using System.Text.Json;

namespace Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public UsuariosController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "IsAdmin")]
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var usuarios = await _uow.UsuarioRepository.Get();

            var usuariosSaidaDto = _mapper.Map<List<UsuarioSaidaDto>>(usuarios);

            var usuariosSaidaDtoPaged = PagedList<UsuarioSaidaDto>.ToPagedList(usuariosSaidaDto, parameters.PageNumber, parameters.PageSize);

            var metadata = new
            {
                usuariosSaidaDtoPaged.PageSize,
                usuariosSaidaDtoPaged.TotalCount,
                usuariosSaidaDtoPaged.CurrentPage,
                usuariosSaidaDtoPaged.TotalPages,
                usuariosSaidaDtoPaged.HasNext,
                usuariosSaidaDtoPaged.HasPrevious
            };


            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            return Ok(usuariosSaidaDtoPaged);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "IsAdmin")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var usuario = await _uow.UsuarioRepository.GetById(id);
            return Ok(usuario);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "IsAdmin")]
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "IsAdmin")]
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
