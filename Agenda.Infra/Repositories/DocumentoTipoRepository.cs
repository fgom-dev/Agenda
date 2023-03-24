using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;

namespace Agenda.Infra.Repositories
{
    public class DocumentoTipoRepository : Repository<DocumentoTipo>, IDocumentoTipoRepository
    {
        public DocumentoTipoRepository(AgendaContext context) : base(context)
        {
        }
    }
}
