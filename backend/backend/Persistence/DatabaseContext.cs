using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
