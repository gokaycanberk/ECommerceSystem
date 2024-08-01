using MediatR;
using ProductService.Models;
using System.Collections.Generic;

namespace ProductService.Features.Products.Queries
{
    public class GetProductsQuery : IRequest<List<Product>> { }
}
