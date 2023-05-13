using Agenda.Domain.DTOs.RecadoTipoDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using Agenda.Shared.Errors;
using AutoMapper;
using System.Net;

namespace Agenda.Infra.Repositories
{
    public class RecadoTipoRepository : Repository<RecadoTipo>, IRecadoTipoRepository
    {
        public RecadoTipoRepository(AgendaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public RecadoTipo Add(RecadoTipoEntradaDto recadoTipoEntrada)
        {
            try
            {
                var recadoTipo = _mapper.Map<RecadoTipo>(recadoTipoEntrada);
                _context.RecadoTipos.Add(recadoTipo);
                return recadoTipo;
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto! ({ex.Message})");
            }
            
        }
    }
}
