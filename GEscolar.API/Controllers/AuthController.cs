﻿using GEscolar.API.Configutarion;
using GEscolar.Commands.Authorization.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GEscolar.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        private IIdentityManager _identityManager;

        public AuthController(IMediator mediator, IIdentityManager identityManager)
        {
            _mediator = mediator;
            _identityManager = identityManager;
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var registered = await _mediator.Send(command);

            if (registered)
            {
                return Ok(registered);
            }

            return BadRequest(registered);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var authenticated = await _mediator.Send(command);

            if (authenticated)
            {
                return Ok(await _identityManager.GenerateJwt(command.Email));
            }

            return Ok(authenticated);
        }
    }
}
