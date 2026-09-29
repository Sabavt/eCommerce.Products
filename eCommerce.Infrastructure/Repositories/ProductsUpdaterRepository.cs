using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore; 

namespace eCommerce.Infrastructure.Repositories;

public class ProductsUpdaterRepository : IProductsUpdaterRepository
{
    private readonly ApplicationDbContext _db;

    public ProductsUpdaterRepository(ApplicationDbContext db)
    { 
        _db = db;
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
