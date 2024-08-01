using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Features.Products.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product?>
    {
        private readonly ApplicationDbContext _context;

        public GetProductByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var product = await _context.Products.FirstOrDefaultAsync(
                p => p.Id == request.Id,
                cancellationToken
            );
            return product;
        }
    }
}
