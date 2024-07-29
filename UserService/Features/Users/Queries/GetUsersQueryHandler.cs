using MediatR;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;
using UserService.Features.Users.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UserService.Features.Users.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly UserDbContext _context;

        public GetUsersQueryHandler(UserDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Handle(
            GetUsersQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _context.Users.ToListAsync();
        }
    }
}
