using GEscolar.Commands.Professores.Command;
using GEscolar.Queries.Professores.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_poc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfessorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertProfessor([FromBody] InsertProfessorCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("FindAll")]
        public async Task<IActionResult> GetProfessores()
        {
            var result = await _mediator.Send(new FindProfessorQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessorById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new FindProfessorByIdQuery { Id = id });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteProfessorCommand { Id = id });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfessor([FromBody] UpdateProfessorCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}