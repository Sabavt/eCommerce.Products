using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using System.Linq.Expressions;

namespace eCommerce.Core.Services;

public class ProductsGetterService : BaseService, IProductsGetterService
{ 
    private readonly IProductsGetterRepository _productsGetterRepository; 

    public ProductsGetterService(IProductsGetterRepository productsGetterRepository, IMapper mapper) : base(mapper)
    {
        _productsGetterRepository = productsGetterRepository; 
    }
      
    public async Task<ProductDTO?> GetProductByCondition(Expression<Func<Product, bool>> expression)
    {
        var product = await _productsGetterRepository.GetProductByCondition(expression);
        var dto_product = _mapper.Map<ProductDTO>(product);

        return dto_product;
    }

    public async Task<List<ProductDTO>> GetProducts()
    {
        var products = await _productsGetterRepository.GetProducts();
        var dto_products = products.Select(p => _mapper.Map<ProductDTO>(p)).ToList();

        return dto_products;
    } 

    public async Task<IEnumerable<ProductDTO>?> GetProductsByCondition(Expression<Func<Product, bool>> expression)
    {
        var products = await _productsGetterRepository.GetProductsByCondition(expression);
        var dto_products = products?.Select(p => _mapper.Map<ProductDTO>(p)).ToList();

        return dto_products;
    }
}
