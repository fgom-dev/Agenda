using Agenda.Domain.DTOs.PessoaDTO;
using Agenda.Domain.Models;

namespace Agenda.Domain.Repositories
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<Pessoa> GetByDocumento(string documento);
        Pessoa Add(PessoaEntradaDto pessoaEntrada);
    }
}
