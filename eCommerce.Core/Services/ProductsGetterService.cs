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
      
    public Task<ProductDTO?> GetProductByCondition(Expression<Func<Product, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductDTO>> GetProducts()
    {
        var products = _productsGetterRepository.GetProducts();
        _mapper.Map<ProductDTO>
    } 

    public Task<IEnumerable<ProductDTO>?> GetProductsByCondition(Expression<Func<Product, bool>> expression)
    {
        throw new NotImplementedException();
    }
}
