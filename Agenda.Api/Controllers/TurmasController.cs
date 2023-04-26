using Agenda.Domain.Models;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories.UOW;
using Agenda.Shared.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Agenda.Api.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public TurmasController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var turmas = await _uow.TurmaRepository.Get(parameters);

            var metadata = new
            {
                turmas.PageSize,
                turmas.TotalCount,
                turmas.CurrentPage,
                turmas.TotalPages,
                turmas.HasNext,
                turmas.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var turma = await _uow.TurmaRepository.GetById(id);
            return Ok(turma);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Turma turma)
        {
            _uow.TurmaRepository.Add(turma);
            await _uow.Commit();
            return Ok(turma);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Turma turmaEntrada)
        {
            if (turmaEntrada.Id != id)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Requisição inválida!");
            }

            var turma = await _uow.TurmaRepository.GetById(id);

            turma.Nome = turmaEntrada.Nome;
            turma.Descricao = turmaEntrada.Descricao;
            turma.Periodo = turmaEntrada.Periodo;

            await _uow.Commit();
            return Ok(turma);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var turma = await _uow.TurmaRepository.GetById(id);
            _uow.TurmaRepository.Delete(turma);
            await _uow.Commit();
            return Ok(turma);
        }
    }
}
