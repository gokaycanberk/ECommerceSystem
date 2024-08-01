using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!; // Non-nullable property initialization

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) { }
    }
}
