using eCommerce.Core.Domain.Entities;
using eCommerce.Core.DTO;
using System.Linq.Expressions;

namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Represents business logic for manipulating products
/// </summary>
public interface IProductsGetterService
{
    /// <summary>
    /// Retrieves all products asynchronously.
    /// </summary>
    /// <returns></returns>
    Task<List<ProductDTO>> GetProducts();

    /// <summary>
    /// Retrieves all products based on the specified details.
    /// </summary>
    /// <param name="expression">expression to check.</param>
    /// <returns>Returning collection of matching products.</returns>
    Task<IEnumerable<ProductDTO>?> GetProductsByCondition(Expression<Func<Product, bool>> expression);

    /// <summary>
    /// Retrieves product based on the specified condition asynchronously.
    /// </summary>
    /// <param name="expression">expression to check.</param>
    /// <returns>Returns matching product.</returns>
    Task<ProductDTO?> GetProductByCondition(Expression<Func<Product, bool>> expression); 
} 