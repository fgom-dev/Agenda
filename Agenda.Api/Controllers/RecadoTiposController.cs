using Agenda.Domain.DTOs.RecadoTipoDTO;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories.UOW;
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
    public class RecadoTiposController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RecadoTiposController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var recadoTipos = await _uow.RecadoTipoRepository.Get(parameters);

            var metadata = new
            {
                recadoTipos.PageSize,
                recadoTipos.TotalCount,
                recadoTipos.CurrentPage,
                recadoTipos.TotalPages,
                recadoTipos.HasNext,
                recadoTipos.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            return Ok(recadoTipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var recadoTipo = await _uow.RecadoTipoRepository.GetById(id);
            return Ok(recadoTipo);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] RecadoTipoEntradaDto recadoTipoEntrada)
        {
            var recadoTipo = _uow.RecadoTipoRepository.Add(recadoTipoEntrada);
            await _uow.Commit();
            return Ok(recadoTipo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] RecadoTipoEntradaDto recadoTipoEntrada)
        {
            if (id != recadoTipoEntrada.Id)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Requisição inválida!");
            }

            var recadoTipo = await _uow.RecadoTipoRepository.GetById(id);

            recadoTipo.Nome = recadoTipoEntrada.Nome;
            recadoTipo.Descricao = recadoTipoEntrada.Descricao;

            _uow.RecadoTipoRepository.Update(recadoTipo);
            await _uow.Commit();
            return Ok(recadoTipo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var recadoTipo = await _uow.RecadoTipoRepository.GetById(id);
            _uow.RecadoTipoRepository.Delete(recadoTipo);
            await _uow.Commit();
            return Ok(recadoTipo);
        }

    }
}
