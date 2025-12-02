using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
        : base(options)
    {
    }
    public ProductContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=InterAdria2;Trusted_Connection=True;");
        }
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Category { get; set; }
}
