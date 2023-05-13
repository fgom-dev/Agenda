using Agenda.Domain.DTOs.RecadoStatusDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using Agenda.Shared.Errors;
using AutoMapper;
using System.Net;

namespace Agenda.Infra.Repositories
{
    public class RecadoStatusRepository : Repository<RecadoStatus>, IRecadoStatusRepository
    {
        public RecadoStatusRepository(AgendaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public RecadoStatus Add(RecadoStatusEntradaDto recadoStatusEntrada)
        {
            try
            {
                var recadoStatus = _mapper.Map<RecadoStatus>(recadoStatusEntrada);
                _context.RecadoStatus.Add(recadoStatus);
                return recadoStatus;
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto! ({ex.Message})");
            }
            
        }
    }
}
