using Agenda.Domain.Models;

namespace Agenda.Domain.DTOs
{
    public class UsuarioDto
    {
        public Guid? Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        public bool IsAdmin { get; set; }
    }
}
