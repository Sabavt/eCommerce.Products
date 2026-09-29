using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class ProductsAdderService : IProductsAdderService
{
    private readonly IProductsAdderRepository _productsAdderRepository;
    private readonly IMapper _mapper;

    public ProductsAdderService(IProductsAdderRepository productsAdderRepository, IMapper mapper)
    {
        _productsAdderRepository = productsAdderRepository;
        _mapper = mapper; 
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