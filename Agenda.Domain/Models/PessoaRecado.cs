namespace Agenda.Domain.Models
{
    public class PessoaRecado : Entity
    {
        public int PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        public int RecadoId { get; set; }
        public Recado? Recado { get; set; }
        public int RecadoStatusId { get; set; }
        public RecadoStatus? RecadoStatus { get; set; }

    }
}
