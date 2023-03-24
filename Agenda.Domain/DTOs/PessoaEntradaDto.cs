namespace Agenda.Domain.DTOs
{
    public class PessoaEntradaDto
    {
        public Guid? Id { get; set; }
        public Guid? PessoaTipoId { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Sexo { get; set; }
        public Guid? DocumentoTipoId { get; set; }
        public string? Documento { get; set; }
    }
}
