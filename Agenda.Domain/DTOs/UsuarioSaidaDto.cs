using Agenda.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.DTOs
{
    public class UsuarioSaidaDto
    {
        public string? Email { get; set; }
        public bool IsAdmin { get; set; }
        public Guid? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}
