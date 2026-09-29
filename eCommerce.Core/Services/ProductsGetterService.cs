using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using System.Linq.Expressions;

namespace eCommerce.Core.Services;

public class ProductsGetterService : IProductsGetterService
{ 
    private readonly IProductsGetterRepository _productsGetterRepository;
    private readonly IMapper _mapper;

    public ProductsGetterService(IProductsGetterRepository productsGetterRepository, IMapper mapper)
    {
        _productsGetterRepository = productsGetterRepository;
        _mapper = mapper;
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

    public Task<IEnumerable<ProductDTO>?> GetProductsByCondition(Expression<Func<Product, bool>> expression)
    {
        throw new NotImplementedException();
    }
}
