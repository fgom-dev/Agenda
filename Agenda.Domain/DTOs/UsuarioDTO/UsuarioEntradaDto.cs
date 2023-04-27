namespace Agenda.Domain.DTOs.UsuarioDTO
{
    public class UsuarioEntradaDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? PessoaId { get; set; }
    }
}
