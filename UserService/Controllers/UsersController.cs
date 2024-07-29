using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserService.Features.Users.Queries;
using UserService.Features.Users.Commands;
using UserService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var query = new GetUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserCommand command)
        {
            var user = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}
