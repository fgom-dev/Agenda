﻿using Agenda.Domain.Models;

namespace Agenda.Domain.DTOs
{
    public class UsuarioEntradaDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Guid? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}
