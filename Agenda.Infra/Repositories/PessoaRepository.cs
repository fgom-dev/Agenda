using Agenda.Domain.Models;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using Agenda.Shared.Errors;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Agenda.Infra.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(AgendaContext context) : base(context)
        {
        }

        public async Task<PagedList<Pessoa>> Get(PaginationParameters parameters)
        {
            try
            {
                return PagedList<Pessoa>.ToPagedList(await _context.Pessoas.Include(x => x.DocumentoTipo).Include(x => x.PessoaTipo).ToListAsync(), parameters.PageNumber, parameters.PageSize);
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto!");
            }
        }

        public async Task<Pessoa> GetById(Guid id)
        {
            try
            {
                return await _context.Pessoas.Include(x => x.DocumentoTipo).Include(x => x.PessoaTipo).SingleAsync(x => x.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new CustomException(HttpStatusCode.NotFound, "Pessoa não encontrada");
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, "Erro não previsto!");
            }
        }
    }
}
