namespace Agenda.Domain.Models
{
    public class Recado : Entity
    {
        public string? Mensagem { get; set; }
        public string? RecadoTipo { get; set; }        
        public int UsuarioId { get; set; }
    }
}
