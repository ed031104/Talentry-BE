using Infraestructure.Messaging.RabbitMQ.Connection;

namespace Infraestructure.Messaging.RabbitMQ.Configurations;

public sealed class QueueConfiguration : IQueueConfigurator
{
    private readonly IRabbitMqConnection _rabbit;

    public QueueConfiguration(IRabbitMqConnection rabbit)
    {
        _rabbit = rabbit;
    }

    public async Task ConfigureAsync()
    {
        await _rabbit.Channel.QueueDeclareAsync(
            queue: "my_queue",
            durable: true,
            exclusive: false,
            autoDelete: false
        );
        
        await _rabbit.Channel.QueueDeclareAsync(
            queue: "my_queue",
            durable: true,
            exclusive: false,
            autoDelete: false
        );
    }
}