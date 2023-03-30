using Agenda.Domain.Models;
using Agenda.Domain.Pagination;

namespace Agenda.Domain.Repositories
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<PagedList<Pessoa>> Get(PaginationParameters parameters);
        Task<Pessoa> GetById(Guid id);
        Task<Pessoa> GetByDocumento(string documento);
    }
}
