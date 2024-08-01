using MediatR;
using ProductService.Models;

namespace ProductService.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Non-nullable property initialization
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
