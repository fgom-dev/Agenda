using Agenda.Domain.DTOs.RecadoTipoDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using AutoMapper;

namespace Agenda.Infra.Repositories
{
    public class RecadoTipoRepository : Repository<RecadoTipo>, IRecadoTipoRepository
    {
        public RecadoTipoRepository(AgendaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public RecadoTipo Add(RecadoTipoEntradaDto recadoTipoEntrada)
        {
            var recadoTipo = _mapper.Map<RecadoTipo>(recadoTipoEntrada);
            _context.RecadoTipos.Add(recadoTipo);
            return recadoTipo;
        }
    }
}
