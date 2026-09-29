using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Infrastructure.Repositories;

public class ProductsAdderRepository : IProductsAdderRepository
{
    private readonly ApplicationDbContext _db;

    public ProductsAdderRepository(ApplicationDbContext db)
    { 
        _db = db;
    }

    public async Task<Product?> AddProduct(Product productToAdd)
    {
        await _db.Products.AddAsync(productToAdd);
        await _db.SaveChangesAsync();
        return productToAdd;
    } 
}
