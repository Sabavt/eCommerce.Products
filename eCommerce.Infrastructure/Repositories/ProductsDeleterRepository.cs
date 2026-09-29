using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Infrastructure.DatabaseContext; 

namespace eCommerce.Infrastructure.Repositories;

public class ProductsDeleterRepository : IProductsUpdaterRepository
{
    private readonly ApplicationDbContext _db;

    public ProductsDeleterRepository(ApplicationDbContext db)
    { 
        _db = db;
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
} 