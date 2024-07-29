using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Features.Products.Commands;
using ProductService.Features.Products.Queries;
using ProductService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var query = new GetProductsQuery();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(CreateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }
    }
}
