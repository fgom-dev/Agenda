using Agenda.Domain.DTOs.DocumentoTipoDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using Agenda.Shared.Errors;
using AutoMapper;
using System.Net;

namespace Agenda.Infra.Repositories
{
    public class DocumentoTipoRepository : Repository<DocumentoTipo>, IDocumentoTipoRepository
    {
        public DocumentoTipoRepository(AgendaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public DocumentoTipo Add(DocumentoTipoEntradaDto documentoTipoEntradaDto)
        {
            try
            {
                var documentoTipo = _mapper.Map<DocumentoTipo>(documentoTipoEntradaDto);
                documentoTipo.CreatedAt = DateTime.UtcNow;
                documentoTipo.UpdatedAt = DateTime.UtcNow;
                _context.DocumentoTipos.Add(documentoTipo);
                return documentoTipo;
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto!");
            }
        }
    }
}
