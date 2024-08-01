using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Features.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
    {
        private readonly UserDbContext _context;

        public GetUserByIdQueryHandler(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _context.Users.FirstOrDefaultAsync(
                u => u.Id == request.Id,
                cancellationToken
            );
            return user;
        }
    }
}
