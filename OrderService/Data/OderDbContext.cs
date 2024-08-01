using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; } = null!; // Non-nullable property initialization

        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options) { }
    }
}
