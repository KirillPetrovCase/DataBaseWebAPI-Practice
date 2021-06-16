using Microsoft.EntityFrameworkCore;

namespace DataBaseWebAPI.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) => Database.EnsureCreated();
    }
}
