using MediatR;
using ProductService.Data;
using ProductService.Models;
using ProductService.Features.Products.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Features.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly ApplicationDbContext _context;

        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken
        )
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
