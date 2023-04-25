using GEscolar.Commands.NoticacaoNotas.Command;
using GEscolar.Queries.NotificacaoNotas.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_poc.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacaoNotaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificacaoNotaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertNotificacaoCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("usuario/{idUsuario}")]
        public async Task<IActionResult> GetByIdUsuario([FromRoute] Guid idUsuario)
        {
            var result = await _mediator.Send(new FindNotificacaoByIdUsuarioQuery { IdUsuario = idUsuario });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteNotificacaoCommand { Id = id });

            return Ok(result);
        }
    }
}