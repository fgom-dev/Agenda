using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;

namespace Agenda.Infra.Repositories
{
    public class PessoaTipoRepository : Repository<PessoaTipo>, IPessoaTipoRepository
    {
        public PessoaTipoRepository(AgendaContext context) : base(context)
        {
        }
    }
}
