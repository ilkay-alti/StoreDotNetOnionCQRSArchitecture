using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreOnionArchitecture.Application.Features.Auth.Command.Login;
using StoreOnionArchitecture.Application.Features.Auth.Command.RefleshToken;
using StoreOnionArchitecture.Application.Features.Auth.Command.Register;
using StoreOnionArchitecture.Application.Features.Auth.Command.Revoke;
using StoreOnionArchitecture.Application.Features.Auth.Command.RevokeAll;

namespace StoreOnionArchitecture.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke([FromBody] RevokeCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RevokeAll()
        {
            var response = await _mediator.Send(new RevokeAllCommandRequest());
            return Ok();
        }
    }
}
