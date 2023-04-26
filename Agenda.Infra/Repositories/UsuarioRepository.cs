using Agenda.Domain.DTOs.UsuarioDTO;
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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AgendaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<PagedList<UsuarioSaidaDto>> Get(PaginationParameters parameters)
        {
            try
            {
                var usuarios = await _context.Usuarios.AsNoTracking().ToListAsync();
                var usuariosSaidaDto = _mapper.Map<List<UsuarioSaidaDto>>(usuarios);
                var usuariosSaidaDtoPaged = PagedList<UsuarioSaidaDto>.ToPagedList(usuariosSaidaDto, parameters.PageNumber, parameters.PageSize);
                return usuariosSaidaDtoPaged;
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto!");
            }
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            try
            {
                return await _context.Usuarios.SingleAsync(x => x.Email == email);
            }
            catch (InvalidOperationException)
            {
                throw new CustomException(HttpStatusCode.NotFound, "Usuario não encontrado");
            }
            catch
            {
                throw new CustomException(HttpStatusCode.InternalServerError, $"Erro não previsto!");
            }
        }
    }
}
