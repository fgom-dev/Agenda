using Agenda.Domain.Models;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using Agenda.Shared.Errors;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Agenda.Infra.Repositories
{
    public class PessoaRecadoRepository : Repository<PessoaRecado>, IPessoaRecadoRepository
    {
        public PessoaRecadoRepository(AgendaContext context, IMapper mapper) : base(context, mapper)
        {            
        }

        public async Task<PagedList<PessoaRecado>> Get(PaginationParameters parameters, int pessoaId)
        {
            try
            {
                return PagedList<PessoaRecado>.ToPagedList(await _context.PessoasRecados
                    .Where(x => x.PessoaId == pessoaId)
                    .ToListAsync(), parameters.PageNumber, parameters.PageSize);
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto!");
            }
        }
    }
}
