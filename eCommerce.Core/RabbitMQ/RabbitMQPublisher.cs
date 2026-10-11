using Microsoft.Extensions.Configuration; 
using RabbitMQ.Client;

namespace eCommerce.Core.RabbitMQ;

public class RabbitMQPublisher : IRabbitMQPublisher, IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    private readonly IChannel _channel; 

    public RabbitMQPublisher(IConfiguration configuration)
    {
        _configuration = configuration;

        string hostName = _configuration["RabbitMQ_HostName"]!;
        int port =  Convert.ToInt32(_configuration["RabbitMQ_Port"]!);
        string user = _configuration["RabbitMQ_UserName"]!;
        string pass = _configuration["RabbitMQ_Password"]!;

        var connectionFactory = new ConnectionFactory() { HostName = hostName, Port = port, UserName = user, Password = pass};

        _connection = connectionFactory.CreateConnectionAsync().Result;
        _channel = _connection.CreateChannelAsync().Result;
    }

    public void Dispose()
    {
        _channel.DisposeAsync();
        _connection.DisposeAsync();
    }

    public void Publish<T>(string routingKey, T message)
    {
        throw new NotImplementedException();
    }
} 