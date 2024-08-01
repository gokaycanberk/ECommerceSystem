using MediatR;
using UserService.Models;

namespace UserService.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string UserName { get; set; } = string.Empty; // Non-nullable property initialization
        public string Email { get; set; } = string.Empty; // Non-nullable property initialization
    }
}
