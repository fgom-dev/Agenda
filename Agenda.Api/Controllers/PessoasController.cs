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
    public class PessoasController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public PessoasController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var pessoas = await _uow.PessoaRepository.Get(parameters);

            var metadata = new
            {
                pessoas.PageSize,
                pessoas.TotalCount,
                pessoas.CurrentPage,
                pessoas.TotalPages,
                pessoas.HasNext,
                pessoas.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var pessoa = await _uow.PessoaRepository.GetById(id);
            return Ok(pessoa);
        }

        [HttpGet("documento/{documento}")]
        public async Task<ActionResult> GetByDocumento(string documento)
        {
            var pessoa = await _uow.PessoaRepository.GetByDocumento(documento);
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaEntradaDto pessoaEntradaDto)
        {
            var pessoa = _uow.PessoaRepository.Add(pessoaEntradaDto);
            await _uow.Commit();
            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PessoaEntradaDto pessoaEntradaDto)
        {
            if (id != pessoaEntradaDto.Id)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Requisição inválida!");
            }

            var pessoa = await _uow.PessoaRepository.GetById(id);

            pessoa.PessoaTipoId = pessoaEntradaDto.PessoaTipoId;
            pessoa.Nome = pessoaEntradaDto.Nome;
            pessoa.Sobrenome = pessoaEntradaDto.Sobrenome;
            pessoa.DataNascimento = pessoaEntradaDto.DataNascimento;
            pessoa.Sexo = pessoaEntradaDto.Sexo;
            pessoa.DocumentoTipoId = pessoaEntradaDto.DocumentoTipoId;
            pessoa.Documento = pessoaEntradaDto.Documento;
            pessoa.TurmaId = pessoaEntradaDto.TurmaId;

            _uow.PessoaRepository.Update(pessoa);
            await _uow.Commit();

            return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pessoa = await _uow.PessoaRepository.GetById(id);
            _uow.PessoaRepository.Delete(pessoa);
            await _uow.Commit();
            return Ok(pessoa);
        }
    }
}
