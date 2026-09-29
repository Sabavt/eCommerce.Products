using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class ProductsAdderService : BaseService, IProductsAdderService
{
    private readonly IProductsAdderRepository _productsAdderRepository; 

    public ProductsAdderService(IProductsAdderRepository productsAdderRepository, IMapper mapper) : base(mapper)
    {
        _productsAdderRepository = productsAdderRepository; 
    }

    public async Task<ProductDTO?> AddProduct(ProductDTO productToAdd)
    {
        var product = _mapper.Map<Product>(productToAdd);

        await _productsAdderRepository.AddProduct(product);

        if (product is null)
            return null;
        else
            return productToAdd;
    }
}