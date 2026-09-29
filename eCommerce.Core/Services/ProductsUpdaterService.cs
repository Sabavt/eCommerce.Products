using AutoMapper;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class ProductsUpdaterService : BaseService, IProductsUpdaterService 
{
    private readonly IProductsGetterRepository _productsGetterRepository; 

    public ProductsUpdaterService(IProductsGetterRepository productsGetterRepository, IMapper mapper) : base(mapper)
    {
        _productsGetterRepository = productsGetterRepository; 
    }

    public Task<ProductDTO?> UpdateProduct(ProductDTO productToUpdate)
    { 
        throw new NotImplementedException();
    }
}
