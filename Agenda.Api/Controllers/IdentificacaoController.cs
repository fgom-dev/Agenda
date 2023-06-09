﻿using Agenda.Domain.DTOs.UsuarioDTO;
using Agenda.Domain.Models;
using Agenda.Domain.Repositories.UOW;
using Agenda.Domain.Services;
using Agenda.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificacaoController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public IdentificacaoController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> RegistraUsuario([FromBody] UsuarioEntradaDto usuarioEntradaDto)
        {
            var usuario = new Usuario
            {
                Email = usuarioEntradaDto.Email,
                PasswordHash = Crypt.GerarHash(usuarioEntradaDto.Password!),
                PessoaId = usuarioEntradaDto.PessoaId,
            };
            _uow.UsuarioRepository.Add(usuario);
            await _uow.Commit();
            return Ok(TokenService.GeraToken(usuario));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UsuarioLoginDto usuarioLoginDto)
        {
            var usuario = await _uow.UsuarioRepository.GetByEmail(usuarioLoginDto.Email!);

            Crypt.Comparar(usuario.PasswordHash!, usuarioLoginDto.Password!);

            return Ok(TokenService.GeraToken(usuario));

        }
    }
}
