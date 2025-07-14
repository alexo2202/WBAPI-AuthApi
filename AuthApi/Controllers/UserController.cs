using Application.MediatR.Users.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [EnableCors("MyPolicy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<bool> CreateAsync(CreateUserCommand user)
        {
            await _mediator.Send(user);
            return true;
        }
    }
}
