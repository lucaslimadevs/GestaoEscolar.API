using GEscolar.Commands.Disciplinas.Command;
using GEscolar.Queries.Disciplinas.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_poc.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DisciplinaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertDisciplinaCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("FindAll")]
        public async Task<IActionResult> GetAll([FromQuery] FindDisciplinaQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new FindDisciplinaByIdQuery { Id = id });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteDisciplinaCommand { Id = id });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDisciplinaCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}