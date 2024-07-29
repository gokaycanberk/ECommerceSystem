using MediatR;
using OrderService.Data;
using OrderService.Models;
using OrderService.Features.Orders.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Features.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken
        )
        {
            var order = new Order
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                OrderDate = request.OrderDate
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
