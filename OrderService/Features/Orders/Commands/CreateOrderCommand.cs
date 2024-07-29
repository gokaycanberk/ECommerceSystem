using MediatR;
using OrderService.Models;

namespace OrderService.Features.Orders.Commands
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
