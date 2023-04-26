using Agenda.Domain.DTOs.DocumentoTipoDTO;
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
    public class DocumentoTiposController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public DocumentoTiposController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var documentoTipos = await _uow.DocumentoTipoRepository.Get(parameters);

            var metadata = new
            {
                documentoTipos.TotalCount,
                documentoTipos.PageSize,
                documentoTipos.CurrentPage,
                documentoTipos.TotalPages,
                documentoTipos.HasNext,
                documentoTipos.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            return Ok(documentoTipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var documentoTipo = await _uow.DocumentoTipoRepository.GetById(id);
            return Ok(documentoTipo);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DocumentoTipoEntradaDto documentoTipoEntradaDto)
        {
            var documentoTipo = _uow.DocumentoTipoRepository.Add(documentoTipoEntradaDto);
            await _uow.Commit();
            return Ok(documentoTipo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DocumentoTipoEntradaDto documentoTipoEntradaDto)
        {
            if (id != documentoTipoEntradaDto.Id)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Requisição inválida!");
            }

            var documentoTipo = await _uow.DocumentoTipoRepository.GetById(id);

            documentoTipo.Nome = documentoTipoEntradaDto.Nome;
            documentoTipo.Descricao = documentoTipoEntradaDto.Descricao;

            _uow.DocumentoTipoRepository.Update(documentoTipo);
            await _uow.Commit();
            return Ok(documentoTipo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var documentoTipo = await _uow.DocumentoTipoRepository.GetById(id);
            _uow.DocumentoTipoRepository.Delete(documentoTipo);
            await _uow.Commit();
            return Ok(documentoTipo);
        }
    }
}
