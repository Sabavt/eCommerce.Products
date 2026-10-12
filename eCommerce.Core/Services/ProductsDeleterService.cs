using AutoMapper; 
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.RabbitMQ;
using eCommerce.Core.RabbitMQ.Messages;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class ProductsDeleterService : BaseService, IProductsDeleterService 
{
    private readonly IProductsDeleterRepository _productsDeleterRepository; 

    public ProductsDeleterService(IProductsDeleterRepository productsDeleterRepository, IMapper mapper, IRabbitMQPublisher rabbitMQPublisher) : base(mapper, rabbitMQPublisher)
    {
        _productsDeleterRepository = productsDeleterRepository; 
    }

    public async Task<bool> DeleteProduct(int productIDtoDelete)
    {
        var isDeleted = await _productsDeleterRepository.DeleteProduct(productIDtoDelete);

        ProductDeletedMessage productDeletedMessage = new(productIDtoDelete);
        await _rabbitMQPublisher.Publish("products.delete.productid", productIDtoDelete);

        if (isDeleted)
            return true;
        else
            return false;
    }
} 