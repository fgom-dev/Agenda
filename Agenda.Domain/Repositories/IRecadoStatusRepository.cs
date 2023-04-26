using Agenda.Domain.DTOs.RecadoStatusDTO;
using Agenda.Domain.Models;

namespace Agenda.Domain.Repositories
{
    public interface IRecadoStatusRepository : IRepository<RecadoStatus>
    {
        RecadoStatus Add(RecadoStatusEntradaDto recadoStatusEntrada);
    }
}
