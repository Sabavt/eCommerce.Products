using eCommerce.Core.DTO; 

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Represents business logic for adding products
/// </summary>
internal interface IProductsAdderService
{  
    /// <summary>
    /// Adds a new product asynchronously, if product is valid.
    /// </summary>
    /// <param name="productToAdd">Product to add.</param>
    /// <returns>Returns newly added product, otherwise null.</returns>
    Task<ProductDTO?> AddProduct(ProductDTO productToAdd); 
} 