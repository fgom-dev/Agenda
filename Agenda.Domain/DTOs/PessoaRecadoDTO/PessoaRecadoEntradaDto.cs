using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.DTOs.PessoaRecadoDTO
{
    public class PessoaRecadoEntradaDto
    {
        public int Id { get; set; }
        public int RecadoId { get; set; }
        public int[]? PessoaIds { get; set; }
    }
}
