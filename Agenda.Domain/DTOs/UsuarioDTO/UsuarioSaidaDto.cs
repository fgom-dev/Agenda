using Agenda.Domain.Models;

namespace Agenda.Domain.DTOs.UsuarioDTO
{
    public class UsuarioSaidaDto
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }
        public int? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}
