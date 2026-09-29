using eCommerce.Core.DTO; 

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Represents business logic for updating products
/// </summary>
public interface IProductsUpdaterService
{ 
    /// <summary>
    /// Updates product entity.
    /// </summary>
    /// <param name="productToUpdate"></param>
    /// <returns>Returns newly updated product, otherwise null.</returns>
    Task<ProductDTO?> UpdateProduct(ProductDTO productToUpdate); 
} 