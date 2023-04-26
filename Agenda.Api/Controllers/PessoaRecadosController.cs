using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories.UOW;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Agenda.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaRecadosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public PessoaRecadosController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var email = User.Claims.Where(x => x.Type == ClaimTypes.Email).Select(c => c.Value).ToList()[0];
            var usuario = await _uow.UsuarioRepository.GetByEmail(email);

            if (usuario.PessoaId == null)
            {
                return NotFound("Você não tem recados!");
            }

            var pessoaRecados = await _uow.PessoaRecadoRepository.Get(parameters, (int)usuario.PessoaId);

            var metadata = new
            {
                pessoaRecados.TotalCount,
                pessoaRecados.PageSize,
                pessoaRecados.CurrentPage,
                pessoaRecados.TotalPages,
                pessoaRecados.HasNext,
                pessoaRecados.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            return Ok(pessoaRecados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var pessoaRecado = await _uow.PessoaRecadoRepository.GetById(id);
            return Ok(pessoaRecado);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("Autorizar/{id}")]
        public async Task<ActionResult> Autorizar(int id)
        {
            var pessoaRecado = await _uow.PessoaRecadoRepository.GetById(id);
            _uow.PessoaRecadoRepository.Update(pessoaRecado);
            await _uow.Commit();
            return Ok(pessoaRecado);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("Cancelar/{id}")]
        public async Task<ActionResult> Cancelar(int id)
        {
            var pessoaRecado = await _uow.PessoaRecadoRepository.GetById(id);
            _uow.PessoaRecadoRepository.Update(pessoaRecado);
            await _uow.Commit();
            return Ok(pessoaRecado);
        }
    }
}
