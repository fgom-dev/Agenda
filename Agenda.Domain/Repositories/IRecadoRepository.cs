using Agenda.Domain.DTOs.RecadoDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Pagination;

namespace Agenda.Domain.Repositories
{
    public interface IRecadoRepository : IRepository<Recado>
    {
        Task<PagedList<Recado>> Get(PaginationParameters parameters, int usuarioId);
        Recado Add(RecadoEntradaDto recadoEntrada, int usuarioId);
        void Update(Recado recado);
    }
}
