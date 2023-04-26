namespace Agenda.Domain.Models
{
    public class Pessoa : Entity
    {
        public int? PessoaTipoId { get; set; }
        public PessoaTipo? PessoaTipo { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Sexo { get; set; }
        public int? DocumentoTipoId { get; set; }
        public DocumentoTipo? DocumentoTipo { get; set; }
        public string? Documento { get; set; }
        public int? TurmaId { get; set; }
        public Turma? Turma { get; set; }
    }
}
