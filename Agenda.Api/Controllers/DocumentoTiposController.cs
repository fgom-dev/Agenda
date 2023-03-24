using Agenda.Domain.DTOs;
using Agenda.Domain.Models;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories.UOW;
using Agenda.Shared.Errors;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoTiposController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public DocumentoTiposController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentoTipo>>> GetAll([FromQuery] PaginationParameters parameters)
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
        public async Task<ActionResult<DocumentoTipo>> GetById(Guid id)
        {
            var documentoTipo = await _uow.DocumentoTipoRepository.GetById(id);
            return Ok(documentoTipo);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentoTipo>> Post([FromBody] DocumentoTipoEntradaDto documentoTipoEntradaDto)
        {
            var documentoTipo = _mapper.Map<DocumentoTipo>(documentoTipoEntradaDto);
            _uow.DocumentoTipoRepository.Add(documentoTipo);
            await _uow.Commit();            
            return Ok(documentoTipo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DocumentoTipo>> Put(Guid id, [FromBody] DocumentoTipoEntradaDto documentoTipoEntradaDto)
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
        public async Task<ActionResult<DocumentoTipo>> Delete(Guid id)
        {
            var documentoTipo = await _uow.DocumentoTipoRepository.GetById(id);
            _uow.DocumentoTipoRepository.Delete(documentoTipo);
            await _uow.Commit();
            return Ok(documentoTipo);
        }
    }
}
