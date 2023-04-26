using Agenda.Domain.Models;
using Agenda.Domain.Pagination;

namespace Agenda.Domain.Repositories
{
    public interface IPessoaRecadoRepository : IRepository<PessoaRecado>
    {
        Task<PagedList<PessoaRecado>> Get(PaginationParameters parameters, int usuarioId);
    }
}
