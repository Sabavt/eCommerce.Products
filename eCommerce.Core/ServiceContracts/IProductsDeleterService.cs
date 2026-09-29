namespace eCommerce.Core.ServiceContracts;

/// <summary>
/// Represents business logic for deleting products
/// </summary>
internal interface IProductsDeleterService
{ 
    /// <summary>
    /// Removes specified product, if id is valid.
    /// </summary>
    /// <param name="productIDtoDelete"></param>
    /// <returns>Returns true if deleted, otherwise false.</returns>
    Task<bool> DeleteProduct(Guid productIDtoDelete);
} 