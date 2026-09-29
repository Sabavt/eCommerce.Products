using eCommerce.Core.Domain.Entities; 

namespace eCommerce.Core.Domain.RepositoryContracts;

/// <summary>
/// Repository for adding persons table
/// </summary>
public interface IProductsAdderRepository
{  
    /// <summary>
    /// Adds new product asynchronously into data set.
    /// </summary>
    /// <param name="product">Product to add.</param>
    /// <returns>Returns newly added product if added, otherwise null.</returns>
    Task<Product?> AddProduct(Product productToAdd);  
} 