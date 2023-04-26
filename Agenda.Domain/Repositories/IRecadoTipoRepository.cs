using Agenda.Domain.DTOs.RecadoTipoDTO;
using Agenda.Domain.Models;

namespace Agenda.Domain.Repositories
{
    public interface IRecadoTipoRepository : IRepository<RecadoTipo>
    {
        RecadoTipo Add(RecadoTipoEntradaDto recadoTipoEntrada);
    }
}
