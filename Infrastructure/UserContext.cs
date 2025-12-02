using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {

    }
    public UserContext()
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=InterAdria2;Trusted_Connection=True;");
        }
    }

    public virtual DbSet<User> User { get; set; }
}
