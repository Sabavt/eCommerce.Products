using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class ProductsUpdaterService : BaseService, IProductsUpdaterService 
{
    private readonly IProductsUpdaterRepository _productsUpdaterRepository; 

    public ProductsUpdaterService(IProductsUpdaterRepository productsUpdaterRepository, IMapper mapper) : base(mapper)
    {
        _productsUpdaterRepository = productsUpdaterRepository; 
    }

    public async Task<ProductDTO?> UpdateProduct(ProductDTO productToUpdate)
    {
        var product = _mapper.Map<Product>(productToUpdate);
        var result = await _productsUpdaterRepository.UpdateProduct(product);

        if (result is not null)
            return productToUpdate;
        else
            return null;
    }
} 