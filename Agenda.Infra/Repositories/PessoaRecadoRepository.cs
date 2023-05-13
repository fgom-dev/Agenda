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

        public async Task<PagedList<PessoaRecado>> GetAll(PaginationParameters parameters)
        {
            try
            {
                return PagedList<PessoaRecado>.ToPagedList(await _context.PessoasRecados
                    .ToListAsync(), parameters.PageNumber, parameters.PageSize);
            }
            catch (Exception ex) 
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto! ({ex.Message})");
            }
        }

        public async Task<PagedList<PessoaRecado>> GetByUserId(PaginationParameters parameters, int pessoaId)
        {
            try
            {
                return PagedList<PessoaRecado>.ToPagedList(await _context.PessoasRecados
                    .Where(x => x.PessoaId == pessoaId && x.RecadoStatusId == 1)                    
                    .ToListAsync(), parameters.PageNumber, parameters.PageSize);
            }
            catch (Exception ex) 
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto! ({ex.Message})");
            }
        }
    }
}
