namespace Infraestructure.Messaging.RabbitMQ.Configurations;

public interface IQueueConfigurator
{
    Task ConfigureAsync();
}