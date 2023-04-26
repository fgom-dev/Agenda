namespace Agenda.Domain.Models
{
    public class Recado : Entity
    {
        public string? Mensagem { get; set; }
        public int RecadoTipoId { get; set; }
        public RecadoTipo? RecadoTipo { get; set; }        
        public int UsuarioId { get; set; }
    }
}
