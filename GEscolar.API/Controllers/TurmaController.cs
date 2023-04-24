using GEscolar.Commands.Turmas.Command;
using GEscolar.Queries.Turmas.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_poc.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TurmaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertTurmaCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("FindAll")]
        public async Task<IActionResult> GetAll([FromQuery] FindTurmaQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new FindTurmaByIdQuery { Id = id });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteTurmaCommand { Id = id });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTurmaCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}