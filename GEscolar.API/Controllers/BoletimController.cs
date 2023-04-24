using GEscolar.Commands.Boletins.Command;
using GEscolar.Queries.Boletins.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_poc.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BoletimController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoletimController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertBoletimCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("FindAll")]
        public async Task<IActionResult> GetAll([FromQuery] FindBoletimQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new FindBoletimByIdQuery { Id = id });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteBoletimCommand { Id = id });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBoletimCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}