using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using AutoMapper;

namespace Agenda.Infra.Repositories
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(AgendaContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
