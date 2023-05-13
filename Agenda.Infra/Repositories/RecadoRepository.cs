using Agenda.Domain.DTOs.RecadoDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using Agenda.Shared.Errors;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Agenda.Infra.Repositories
{
    public class RecadoRepository : Repository<Recado>, IRecadoRepository
    {
        public RecadoRepository(AgendaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Recado Add(RecadoEntradaDto recadoEntrada, int usuarioId)
        {
            try
            {
                var recado = _mapper.Map<Recado>(recadoEntrada);
                recado.UsuarioId = usuarioId;
                recado.CreatedAt = DateTime.UtcNow;
                recado.UpdatedAt = DateTime.UtcNow;
                _context.Recados.Add(recado);
                return recado;
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto! ({ex.Message})");
            }
            
        }

        public async Task<PagedList<Recado>> Get(PaginationParameters parameters, int usuarioId)
        {
            try
            {
                return PagedList<Recado>.ToPagedList(await _context.Recados
                    .Where(x => x.UsuarioId == usuarioId)
                    .ToListAsync(), parameters.PageNumber, parameters.PageSize);
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto! ({ex.Message})");
            }
        }

        void IRecadoRepository.Update(Recado recado)
        {
            try
            {
                recado.UpdatedAt = DateTime.UtcNow;
                _context.Recados.Update(recado);
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto! ({ex.Message})");
            }
        }
    }
}
