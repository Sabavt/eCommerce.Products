using AutoMapper;
using eCommerce.Core.RabbitMQ;

namespace eCommerce.Core.Services;

public abstract class BaseService
{ 
    protected readonly IMapper _mapper;
    protected readonly IRabbitMQPublisher _rabbitMQPublisher;

    public BaseService(IMapper mapper, IRabbitMQPublisher rabbitMQPublisher)
    { 
        _mapper = mapper;
        _rabbitMQPublisher = rabbitMQPublisher;
    } 
}
