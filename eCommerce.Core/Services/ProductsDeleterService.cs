using AutoMapper; 
using eCommerce.Core.Domain.RepositoryContracts; 
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class ProductsDeleterService : BaseService, IProductsDeleterService 
{
    private readonly IProductsDeleterRepository _productsDeleterRepository; 

    public ProductsDeleterService(IProductsDeleterRepository productsDeleterRepository, IMapper mapper) : base(mapper)
    {
        _productsDeleterRepository = productsDeleterRepository; 
    }

    public async Task<bool> DeleteProduct(Guid productIDtoDelete)
    {
        return await _productsDeleterRepository.DeleteProduct(productIDtoDelete);
    }
}
