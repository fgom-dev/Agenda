using Agenda.Domain.Models;

namespace Agenda.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByEmail(string email);
    }
}
