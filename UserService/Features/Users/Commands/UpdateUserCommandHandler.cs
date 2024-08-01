using MediatR;
using UserService.Data;
using UserService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Features.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly UserDbContext _context;

        public UpdateUserCommandHandler(UserDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            UpdateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _context.Users.FindAsync(request.Id);

            if (user == null)
            {
                return false;
            }

            user.UserName = request.UserName;
            user.Email = request.Email;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
