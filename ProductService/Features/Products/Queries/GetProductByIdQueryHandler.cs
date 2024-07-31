using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Features.Products.Queries;
using ProductService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Features.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly ApplicationDbContext _context;

        public GetProductByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var product = await _context.Products.FindAsync(request.Id);

            if (product == null)
            {
                // Optional: Handle not found case
                return null;
            }

            return product;
        }
    }
}
