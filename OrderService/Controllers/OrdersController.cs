using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Features.Orders.Commands;
using OrderService.Features.Orders.Queries;
using OrderService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var query = new GetOrdersQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(CreateOrderCommand command)
        {
            var order = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);
        }
    }
}
