using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Infrastructure.Repositories;

public class ProductsRepository : IProductsUpdaterRepository
{
    private readonly ApplicationDbContext _db;

    public ProductsRepository(ApplicationDbContext db)
    { 
        _db = db;
    }
    public async Task<Product?> AddProduct(Product productToAdd)
    {
        await _db.Products.AddAsync(productToAdd);
        await _db.SaveChangesAsync();
        return productToAdd;
    }

    public async Task<bool> DeleteProduct(Guid productIDtoDelete)
    {
        var result = _db.Products.Remove(new Product { ProductID = productIDtoDelete });
        await _db.SaveChangesAsync();
        if(result != null)
        {
            return true;
        }
        return false;
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

    public async Task<Product?> UpdateProduct(Product productToUpdate)
    {
        var product = await _db.Products.SingleOrDefaultAsync(t => t.ProductID == productToUpdate.ProductID);

        if(product is not null)
        {
            product.ProductName = productToUpdate.ProductName;
            product.Price = productToUpdate.Price;
            product.Quantity = productToUpdate.Quantity;
            product.ProductDescription = productToUpdate.ProductDescription;
            await _db.SaveChangesAsync();
        }
        return null;
    }
}
