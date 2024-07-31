using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Features.Users.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Features.Users.Handlers
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

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
