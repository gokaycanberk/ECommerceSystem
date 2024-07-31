using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Features.Orders.Queries;
using OrderService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Features.Orders.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly OrderDbContext _context;

        public GetOrderByIdQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(
            GetOrderByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var order = await _context.Orders.FindAsync(request.Id);

            if (order == null)
            {
                // Optional: Handle not found case
                return null;
            }

            return order;
        }
    }
}
