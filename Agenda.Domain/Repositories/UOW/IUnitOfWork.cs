namespace Agenda.Domain.Repositories.UOW
{
    public interface IUnitOfWork
    {
        IPessoaRepository PessoaRepository { get; }
        IDocumentoTipoRepository DocumentoTipoRepository { get; }
        IPessoaTipoRepository PessoaTipoRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        ITurmaRepository TurmaRepository { get; }
        IRecadoTipoRepository RecadoTipoRepository { get; }
        IRecadoStatusRepository RecadoStatusRepository { get; }
        IRecadoRepository RecadoRepository { get; }
        IPessoaRecadoRepository PessoaRecadoRepository { get; }
        Task Commit();
    }
}
