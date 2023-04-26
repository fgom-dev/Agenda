using Agenda.Domain.DTOs.RecadoDTO;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories.UOW;
using Agenda.Shared.Errors;
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
    public class RecadosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RecadosController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).Select(c => c.Value).ToList()[0];
            var usuario = await _uow.UsuarioRepository.GetByEmail(email);

            var recados = await _uow.RecadoRepository.Get(parameters, usuario.Id);

            var metadata = new
            {
                recados.TotalCount,
                recados.PageSize,
                recados.CurrentPage,
                recados.TotalPages,
                recados.HasNext,
                recados.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            return Ok(recados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var recado = await _uow.RecadoRepository.GetById(id);
            return Ok(recado);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RecadoEntradaDto recadoEntradaDto)
        {
            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).Select(c => c.Value).ToList()[0];
            var usuario = await _uow.UsuarioRepository.GetByEmail(email);
            var recado = _uow.RecadoRepository.Add(recadoEntradaDto, usuario.Id);
            await _uow.Commit();
            return Ok(recado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RecadoEntradaDto recadoEntradaDto)
        {
            if (id != recadoEntradaDto.Id)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Requisição inválida!");
            }

            var recado = await _uow.RecadoRepository.GetById(id);

            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).Select(c => c.Value).ToList()[0];
            var usuario = await _uow.UsuarioRepository.GetByEmail(email);

            if (recado.UsuarioId != usuario.Id)
            {
                throw new CustomException(HttpStatusCode.Unauthorized, "Você não pode alterar esse recado!");
            }

            recado.Mensagem = recadoEntradaDto.Mensagem;
            recado.RecadoTipoId = recadoEntradaDto.RecadoTipoId;

            _uow.RecadoRepository.Update(recado);
            await _uow.Commit();
            return Ok(recado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var recado = await _uow.RecadoRepository.GetById(id);

            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).Select(c => c.Value).ToList()[0];
            var usuario = await _uow.UsuarioRepository.GetByEmail(email);

            if (recado.UsuarioId != usuario.Id)
            {
                throw new CustomException(HttpStatusCode.Unauthorized, "Você não pode deletar esse recado!");
            }

            _uow.RecadoRepository.Delete(recado);
            await _uow.Commit();
            return Ok(recado);
        }        
    }
}
