﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.DTOs
{
    public class UsuarioLoginDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}