using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Features.Users.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Features.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly UserDbContext _context;

        public DeleteUserCommandHandler(UserDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            DeleteUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _context.Users.FindAsync(request.Id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
