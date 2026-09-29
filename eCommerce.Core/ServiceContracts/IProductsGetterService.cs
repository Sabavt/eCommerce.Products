using eCommerce.Core.DTO; 

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Represents business logic for manipulating products
/// </summary>
internal interface IProductsGetterService
{
    /// <summary>
    /// Retrieves all products asynchronously.
    /// </summary>
    /// <returns></returns>
    Task<List<ProductDTO>> GetProducts();

    /// <summary>
    /// Retrieves all products based on the specified details.
    /// </summary>
    /// <param name="product">The products details to search.</param>
    /// <returns>Returning collection of matching products.</returns>
    Task<IEnumerable<ProductDTO>?> GetProductsByCondition(ProductDTO product);

    /// <summary>
    /// Retrieves product based on the specified condition asynchronously.
    /// </summary>
    /// <param name="product">The product details to search.</param>
    /// <returns>Returns matching product.</returns>
    Task<ProductDTO?> GetProductByCondition(ProductDTO product); 
} 