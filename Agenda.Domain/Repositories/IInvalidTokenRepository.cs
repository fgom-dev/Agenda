using Agenda.Domain.Models;

namespace Agenda.Domain.Repositories
{
    public interface IInvalidTokenRepository : IRepository<InvalidToken>
    {
        Task<InvalidToken> GetByToken(string token);
    }
}
