using Agenda.Domain.DTOs.PessoaDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using Agenda.Shared.Errors;
using AutoMapper;
using System.Net;

namespace Agenda.Infra.Repositories
{
    public class PessoaTipoRepository : Repository<PessoaTipo>, IPessoaTipoRepository
    {
        public PessoaTipoRepository(AgendaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public PessoaTipo Add(PessoaTipoEntradaDto pessoaTipoEntradaDto)
        {
            try
            {
                var pessoaTipo = _mapper.Map<PessoaTipo>(pessoaTipoEntradaDto);
                pessoaTipo.CreatedAt = DateTime.UtcNow;
                pessoaTipo.UpdatedAt = DateTime.UtcNow;
                _context.PessoaTipos.Add(pessoaTipo);
                return pessoaTipo;
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto! ({ex.Message})");
            }
        }
    }
}
