using Agenda.Domain.DTOs.PessoaDTO;
using Agenda.Domain.Models;

namespace Agenda.Domain.Repositories
{
    public interface IPessoaTipoRepository : IRepository<PessoaTipo>
    {
        PessoaTipo Add(PessoaTipoEntradaDto pessoaTipoEntradaDto);
    }
}
