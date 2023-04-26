using Agenda.Domain.DTOs.DocumentoTipoDTO;
using Agenda.Domain.Models;

namespace Agenda.Domain.Repositories
{
    public interface IDocumentoTipoRepository : IRepository<DocumentoTipo>
    {
        DocumentoTipo Add(DocumentoTipoEntradaDto documentoTipoEntradaDto);
    }
}
