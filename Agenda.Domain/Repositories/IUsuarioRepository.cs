using Agenda.Domain.DTOs.UsuarioDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Pagination;

namespace Agenda.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByEmail(string email);
        Task<PagedList<UsuarioSaidaDto>> Get(PaginationParameters parameters);
    }
}
