using Microsoft.EntityFrameworkCore; // Bu satırı ekleyin
using OrderService.Models;

namespace OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
