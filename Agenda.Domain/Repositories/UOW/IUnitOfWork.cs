namespace Agenda.Domain.Repositories.UOW
{
    public interface IUnitOfWork
    {
        IPessoaRepository PessoaRepository { get; }
        IDocumentoTipoRepository DocumentoTipoRepository { get; }
        IPessoaTipoRepository PessoaTipoRepository { get; }
        Task Commit();
    }
}
