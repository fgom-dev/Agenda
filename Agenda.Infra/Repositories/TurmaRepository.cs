using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;

namespace Agenda.Infra.Repositories
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(AgendaContext context) : base(context)
        {
        }
    }
}
