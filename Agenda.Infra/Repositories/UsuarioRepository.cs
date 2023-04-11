using Agenda.Domain.Models;
using Agenda.Domain.Repositories;
using Agenda.Infra.Context;
using Agenda.Shared.Errors;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Agenda.Infra.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AgendaContext context) : base(context)
        {
        }

        public async Task<IList<Usuario>> Get()
        {
            try
            {
                return await _context.Usuarios.AsNoTracking().ToListAsync();
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
