using Agenda.Domain.DTOs.PessoaDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using Agenda.Shared.Errors;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Agenda.Infra.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(AgendaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Pessoa Add(PessoaEntradaDto pessoaEntrada)
        {
            try
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaEntrada);
                _context.Pessoas.Add(pessoa);
                return pessoa;
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto! ({ex.Message})");
            }

        }

        public async Task<Pessoa> GetByDocumento(string documento)
        {
            try
            {
                return await _context.Pessoas.SingleAsync(x => x.Documento == documento);
            }
            catch (InvalidOperationException)
            {
                throw new CustomException(HttpStatusCode.NotFound, "Pessoa não encontrada");
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto! ({ex.Message})");
            }
        }
    }
}
