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
    }
}