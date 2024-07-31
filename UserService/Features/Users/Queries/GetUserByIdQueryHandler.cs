using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Features.Users.Queries;
using UserService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Features.Users.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly UserDbContext _context;

        public GetUserByIdQueryHandler(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _context.Users.FindAsync(request.Id);

            if (user == null)
            {
                // Optional: Handle not found case
                return null;
            }

            return user;
        }
    }
}
