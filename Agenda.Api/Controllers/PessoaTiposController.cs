using Agenda.Domain.DTOs.PessoaDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories.UOW;
using Agenda.Shared.Errors;
using AutoMapper;
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
    public class PessoaTiposController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PessoaTiposController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaTipo>>> GetAll([FromQuery] PaginationParameters parameters)
        {
            var pessoaTipos = await _uow.PessoaTipoRepository.Get(parameters);

            var metadata = new
            {
                pessoaTipos.PageSize,
                pessoaTipos.TotalCount,
                pessoaTipos.CurrentPage,
                pessoaTipos.TotalPages,
                pessoaTipos.HasNext,
                pessoaTipos.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            return Ok(pessoaTipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaTipo>> GetById(Guid id)
        {
            var pessoaTipo = await _uow.PessoaTipoRepository.GetById(id);
            return Ok(pessoaTipo);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaTipo>> Post([FromBody] PessoaTipoEntradaDto pessoaTipoEntradaDto)
        {
            var pessoaTipo = _mapper.Map<PessoaTipo>(pessoaTipoEntradaDto);
            _uow.PessoaTipoRepository.Add(pessoaTipo);
            await _uow.Commit();
            return Ok(pessoaTipo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaTipo>> Put(Guid id, [FromBody] PessoaTipoEntradaDto pessoaTipoEntradaDto)
        {
            if (id != pessoaTipoEntradaDto.Id)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Requisição inválida!");
            }

            var pessoaTipo = await _uow.PessoaTipoRepository.GetById(id);

            pessoaTipo.Nome = pessoaTipoEntradaDto.Nome;
            pessoaTipo.Descricao = pessoaTipoEntradaDto.Descricao;

            _uow.PessoaTipoRepository.Update(pessoaTipo);
            await _uow.Commit();
            return Ok(pessoaTipo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PessoaTipo>> Delete(Guid id)
        {
            var pessoaTipo = await _uow.PessoaTipoRepository.GetById(id);
            _uow.PessoaTipoRepository.Delete(pessoaTipo);
            await _uow.Commit();
            return Ok(pessoaTipo);
        }
    }
}
