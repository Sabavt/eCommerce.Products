namespace eCommerce.Core.RabbitMQ.Messages;

public record ProductAddedMessage(string ProductName, int ProductID);