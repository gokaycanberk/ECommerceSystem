using MediatR;
using OrderService.Models;
using System.Collections.Generic;

namespace OrderService.Features.Orders.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<Order>> { }
}
