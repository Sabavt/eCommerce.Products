using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.Domain.RepositoryContracts;
using eCommerce.Core.DTO;
using eCommerce.Core.RabbitMQ;
using eCommerce.Core.RabbitMQ.Messages;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class ProductsAdderService : BaseService, IProductsAdderService
{
    private readonly IProductsAdderRepository _productsAdderRepository;

    public ProductsAdderService(IProductsAdderRepository productsAdderRepository, IMapper mapper, IRabbitMQPublisher rabbitMQPublisher) : base(mapper, rabbitMQPublisher)
    {
        _productsAdderRepository = productsAdderRepository; 
    }

    public async Task<ProductDTO?> AddProduct(ProductDTO productToAdd)
    {
        var product = _mapper.Map<Product>(productToAdd);

        var added_product = await _productsAdderRepository.AddProduct(product);

        ProductAddedMessage productAddedMessage = new(added_product!.ProductName, added_product.ProductID);
        await _rabbitMQPublisher.Publish("product.added", productAddedMessage);

        if (product is null)
            return null;
        else
            return productToAdd;
    }
}