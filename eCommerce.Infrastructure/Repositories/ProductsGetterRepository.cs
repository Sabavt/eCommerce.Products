using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Infrastructure.Repositories;

public class ProductsGetterRepository : IProductsGetterRepository
{
    private readonly ApplicationDbContext _db;

    public ProductsGetterRepository(ApplicationDbContext db)
    { 
        _db = db;
    }  

    public async Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> filteringCondition)
    {
        return await _db.Products.FirstOrDefaultAsync(filteringCondition);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    { 
        return await _db.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product>?> GetProductsByCondition(Expression<Func<Product, bool>> filteringCondition)
    {
       return await _db.Products.Where(filteringCondition).ToListAsync(); 
    } 
} 