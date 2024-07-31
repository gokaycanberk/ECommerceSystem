using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Features.Products.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Features.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public UpdateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken
        )
        {
            var product = await _context.Products.FindAsync(request.Id);

            if (product == null)
            {
                return false;
            }

            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
