using MediatR;
using UserService.Data;
using UserService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Features.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly UserDbContext _context;

        public CreateUserCommandHandler(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = new User { UserName = request.UserName, Email = request.Email };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
