using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.RabbitMQ;
using eCommerce.Core.RabbitMQ.Messages;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class ProductsUpdaterService : BaseService, IProductsUpdaterService 
{
    private readonly IProductsUpdaterRepository _productsUpdaterRepository; 

    public ProductsUpdaterService(IProductsUpdaterRepository productsUpdaterRepository, IMapper mapper, IRabbitMQPublisher rabbitMQPublisher) : base(mapper, rabbitMQPublisher)
    {
        _productsUpdaterRepository = productsUpdaterRepository; 
    }

    public async Task<ProductDTO?> UpdateProduct(ProductDTO productToUpdate)
    {
        var product = _mapper.Map<Product>(productToUpdate);
        var result = await _productsUpdaterRepository.UpdateProduct(product);
        if(result != null)
        {
            ProductNameUpdateMessage productName = new(result.ProductName);
            await _rabbitMQPublisher.Publish("products.update.ProductName", productName);
        }

        if (result is not null)
            return productToUpdate;
        else
            return null;
    }
} 