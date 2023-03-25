namespace Agenda.Domain.Models
{
    public class Usuario : Entity
    {
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public Guid? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}
