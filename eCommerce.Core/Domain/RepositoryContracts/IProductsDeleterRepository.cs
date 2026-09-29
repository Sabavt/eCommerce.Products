namespace eCommerce.Core.Domain.RepositoryContracts;

/// <summary>
/// Repository for deleting persons table
/// </summary>
public interface IProductsDeleterRepository
{ 
    /// <summary>
    /// Deletes product.
    /// </summary>
    /// <param name="productIDtoDelete"></param>
    /// <returns>Returns true if deleted, otherwise false.</returns>
    Task<bool> DeleteProduct(Guid productIDtoDelete);
} 