using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class ProductsGetterService : IProductsGetterService
{ 
    private readonly IProductsGetterRepository _productsAdderRepository; 

    public ProductsGetterService(IProductsGetterRepository productsAdderRepository)
    {
        _productsAdderRepository = productsAdderRepository; 
    }
     
    public Task<ProductDTO?> GetProductByCondition(string productName = "a", decimal productPrice = 0, CategoryOptions category = CategoryOptions.Groceries)
    { 
    }

    public Task<List<ProductDTO>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDTO>?> GetProductsByCondition(ProductDTO product)
    {
        throw new NotImplementedException();
    }
}
