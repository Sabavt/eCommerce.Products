using eCommerce.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infrastructure.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().ToTable("products2"); 

        modelBuilder.Entity<Product>().Property("Price").HasColumnName("UnitPrice");
        modelBuilder.Entity<Product>().Property("Quantity").HasColumnName("QuantityInStock");
    }
}