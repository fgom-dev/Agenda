using Agenda.Domain.DTOs.RecadoStatusDTO;
using Agenda.Domain.Pagination;
using Agenda.Domain.Repositories.UOW;
using Agenda.Shared.Errors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Agenda.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class RecadoStatusController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RecadoStatusController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] PaginationParameters parameters)
        {
            var recadoStatus = await _uow.RecadoStatusRepository.Get(parameters);

            var metadata = new
            {
                recadoStatus.PageSize,
                recadoStatus.TotalCount,
                recadoStatus.CurrentPage,
                recadoStatus.TotalPages,
                recadoStatus.HasNext,
                recadoStatus.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));

            return Ok(recadoStatus);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var recadoStatus = await _uow.RecadoStatusRepository.GetById(id);
            return Ok(recadoStatus);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RecadoStatusEntradaDto recadoStatusEntrada)
        {
            var recadoStatus = _uow.RecadoStatusRepository.Add(recadoStatusEntrada);
            await _uow.Commit();
            return Ok(recadoStatus);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RecadoStatusEntradaDto recadoStatusEntrada)
        {
            if (id != recadoStatusEntrada.Id)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Requisição inválida!");
            }

            var recadoStatus = await _uow.RecadoStatusRepository.GetById(id);

            recadoStatus.Nome = recadoStatusEntrada.Nome;
            recadoStatus.Descricao = recadoStatusEntrada.Descricao;

            _uow.RecadoStatusRepository.Update(recadoStatus);
            await _uow.Commit();
            return Ok(recadoStatus);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var recadoStatus = await _uow.RecadoStatusRepository.GetById(id);
            _uow.RecadoStatusRepository.Delete(recadoStatus);
            await _uow.Commit();
            return Ok(recadoStatus);
        }
    }
}
