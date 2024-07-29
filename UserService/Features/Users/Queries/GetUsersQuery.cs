using MediatR;
using UserService.Models;
using System.Collections.Generic;

namespace UserService.Features.Users.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<User>> { }
}
