using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Features.Orders.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Features.Orders.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly OrderDbContext _context;

        public DeleteOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            DeleteOrderCommand request,
            CancellationToken cancellationToken
        )
        {
            var order = await _context.Orders.FindAsync(request.Id);

            if (order == null)
            {
                return false;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
