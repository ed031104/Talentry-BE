namespace Infraestructure.Messaging.RabbitMQ.Configurations;

public interface IRabbitMqInitializer
{
    Task InicializeAsync();
}