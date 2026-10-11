using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace eCommerce.Core.RabbitMQ;

public class RabbitMQPublisher : IRabbitMQPublisher
{
    private readonly IConfiguration _configuration;

    public RabbitMQPublisher(IConfiguration configuration)
    {
        _configuration = configuration;

        string hostName = _configuration["RabbitMQ_HostName"]!;
        int port =  Convert.ToInt32(_configuration["RabbitMQ_Port"]!);
        string user = _configuration["RabbitMQ_UserName"]!;
        string pass = _configuration["RabbitMQ_Password"]!;

        new ConnectionFactory() { HostName = hostName, Port = port, UserName = user, Password = pass};
    }
    
    public void Publish<T>(string routingKey, T message)
    {
        throw new NotImplementedException();
    }
} 