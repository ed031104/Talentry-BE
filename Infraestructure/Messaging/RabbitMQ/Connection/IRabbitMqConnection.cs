using RabbitMQ.Client;

namespace Infraestructure.Messaging.RabbitMQ.Connection;

public interface IRabbitMqConnection
{
    IChannel Channel { get; }
}