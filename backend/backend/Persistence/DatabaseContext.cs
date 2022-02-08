using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Group> Group { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Group>((entity =>
            {
                entity.Property(e => e.AuthorizationCode).IsRequired();
                entity.Property(e => e.Name).IsRequired();
            }));

            modelBuilder.Entity<Group>().HasIndex(u => u.Name).IsUnique();
            
            
            #region GroupSeed

            modelBuilder.Entity<Group>().HasData(new Group {AuthorizationCode = "258A52FS", GroupId = 1, Name = "Customer"});
            modelBuilder.Entity<Group>().HasData(new Group {AuthorizationCode = "10AL29S5", GroupId = 2, Name = "Premium Customer"});
            modelBuilder.Entity<Group>().HasData(new Group {AuthorizationCode = "4829ASK1", GroupId = 3, Name = "Interested"});
            
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
