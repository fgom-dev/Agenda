﻿using Agenda.Domain.DTOs;
using Agenda.Domain.Models;
using Agenda.Domain.Repositories.UOW;
using Agenda.Domain.Services;
using Agenda.Shared.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificacaoController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public IdentificacaoController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> RegistraUsuario([FromBody] UsuarioEntradaDto usuarioEntradaDto)
        {
            var usuario = new Usuario
            {
                Email = usuarioEntradaDto.Email,
                PasswordHash = Crypt.GerarHash(usuarioEntradaDto.Password),
            };
            _uow.UsuarioRepository.Add(usuario);
            await _uow.Commit();
            return Ok(TokenService.GeraToken(usuario));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UsuarioEntradaDto usuarioEntradaDto)
        {
            var usuario = await _uow.UsuarioRepository.GetByEmail(usuarioEntradaDto.Email);

            Crypt.Comparar(usuario.PasswordHash, usuarioEntradaDto.Password);
            
            return Ok(TokenService.GeraToken(usuario));           
            
        }
    }
}