using GEscolar.Commands.Alunos.Command;
using GEscolar.Queries.Alunos.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_poc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlunoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAluno([FromBody] InsertAlunoCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("FindAll")]
        public async Task<IActionResult> GetAlunos()
        {
            var result = await _mediator.Send(new FindAlunoQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlunoById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new FindAlunoByIdQuery { Id = id });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteAlunoCommand { Id = id });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAluno([FromBody] UpdateAlunoCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}