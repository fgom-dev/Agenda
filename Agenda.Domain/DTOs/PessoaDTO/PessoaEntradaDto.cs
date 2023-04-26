namespace Agenda.Domain.DTOs.PessoaDTO
{
    public class PessoaEntradaDto
    {
        public int? Id { get; set; }
        public int? PessoaTipoId { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Sexo { get; set; }
        public int? DocumentoTipoId { get; set; }
        public string? Documento { get; set; }
        public int? TurmaId { get; set; }
    }
}
