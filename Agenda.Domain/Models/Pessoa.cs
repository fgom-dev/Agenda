namespace Agenda.Domain.Models
{
    public class Pessoa : Entity
    {
        public Guid? PessoaTipoId { get; set; }
        public PessoaTipo? PessoaTipo { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Sexo { get; set; }
        public Guid? DocumentoTipoId { get; set; }
        public DocumentoTipo? DocumentoTipo { get; set; }
        public string? Documento { get; set; }
    }
}
