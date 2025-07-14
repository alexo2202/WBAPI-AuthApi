using Application.MediatR.Auth;
using Application.MediatR.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<TokenDto> LoginAsync(LoginQuery user)
        {
            return await _mediator.Send(user);
        }
    }
}
