using GEscolar.Commands.NotasBoletins.Command;
using GEscolar.Queries.NotasBoletins.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_poc.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class NotasBoletimController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotasBoletimController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertNotasBoletimCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("FindAll")]
        public async Task<IActionResult> GetAll([FromQuery] FindNotasBoletimQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new FindNotasBoletimByIdQuery { Id = id });

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteNotasBoletimCommand { Id = id });

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNotasBoletimCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}