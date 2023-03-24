﻿using Agenda.Domain.DTOs;
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
    public class PessoasController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public PessoasController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetAll([FromQuery] PaginationParameters parameters)
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
        public async Task<ActionResult<Pessoa>> GetById(Guid id)
        {
            var pessoa = await _uow.PessoaRepository.GetById(id);
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Post([FromBody] PessoaEntradaDto pessoaEntradaDto)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaEntradaDto);
            _uow.PessoaRepository.Add(pessoa);
            await _uow.Commit();
            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pessoa>> Put(Guid id, [FromBody] PessoaEntradaDto pessoaEntradaDto)
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

            _uow.PessoaRepository.Update(pessoa);
            await _uow.Commit();

            return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> Delete(Guid id)
        {
            var pessoa = await _uow.PessoaRepository.GetById(id);
            _uow.PessoaRepository.Delete(pessoa);
            await _uow.Commit();
            return Ok(pessoa);
        }
    }
}