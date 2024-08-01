using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Features.Products.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Features.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken
        )
        {
            var product = await _context.Products.FindAsync(request.Id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
