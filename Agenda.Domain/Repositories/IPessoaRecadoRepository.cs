using Agenda.Domain.Models;
using Agenda.Domain.Pagination;

namespace Agenda.Domain.Repositories
{
    public interface IPessoaRecadoRepository : IRepository<PessoaRecado>
    {
        Task<PagedList<PessoaRecado>> GetByUserId(PaginationParameters parameters, int usuarioId);
        Task<PagedList<PessoaRecado>> GetAll(PaginationParameters parameters);
    }
}
