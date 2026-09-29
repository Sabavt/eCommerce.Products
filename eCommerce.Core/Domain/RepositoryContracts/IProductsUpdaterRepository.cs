using eCommerce.Core.Domain.Entities; 

namespace eCommerce.Core.Domain.RepositoryContracts;

/// <summary>
/// Repository for updating persons table
/// </summary>
public interface IProductsUpdaterRepository
{ 
    /// <summary>
    /// Updates specific row of products inside data set.
    /// </summary>
    /// <param name="productToUpdate"></param>
    /// <returns>Returns new row of product if updated, otherwise null.</returns>
    Task<Product?> UpdateProduct(Product productToUpdate); 
} 