using eCommerce.Core.Domain.Entities;
using System.Linq.Expressions;

namespace eCommerce.Core.Domain.RepositoryContracts;

/// <summary>
/// Repository for searching persons inside data table
/// </summary>
public interface IProductsGetterRepository
{
    /// <summary>
    /// Retrieves all products asynchronously.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Product>> GetProducts();

    /// <summary>
    /// Retrieves all products based on the specified condition asynchronously.
    /// </summary>
    /// <param name="expression">The condition to filter products.</param>
    /// <returns>Returning collection of matching rows.</returns>
    Task<IEnumerable<Product>?> GetProductsByCondition(Expression<Func<Product, bool>> filteringCondition);
    
    /// <summary>
    /// Retrieves product based on the specified condition asynchronously.
    /// </summary>
    /// <param name="expression">The condition to filter product.</param>
    /// <returns>Returns matching row.</returns>
    Task<Product?> GetProductByCondition(Expression<Func<Product, bool>> filteringCondition); 
} 