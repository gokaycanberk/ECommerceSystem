using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;
using OrderService.Features.Orders.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Features.Orders.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly OrderDbContext _context;

        public GetOrdersQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> Handle(
            GetOrdersQuery request,
            CancellationToken cancellationToken
        )
        {
            return await _context.Orders.ToListAsync();
        }
    }
}
