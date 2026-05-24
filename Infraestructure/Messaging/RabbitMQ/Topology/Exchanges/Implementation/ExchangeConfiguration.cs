using Infraestructure.Messaging.RabbitMQ.Connection;
using RabbitMQ.Client;

namespace Infraestructure.Messaging.RabbitMQ.Configurations;

public sealed class ExchangeConfiguration : IExchangeConfiguration
{
    private readonly IRabbitMqConnection _rabbit;

    public ExchangeConfiguration(IRabbitMqConnection rabbit)
    {
        _rabbit = rabbit;
    }

    public async Task ConfigureAsync()
    {
        await _rabbit.Channel.ExchangeDeclareAsync(
            exchange: "",
            type: ExchangeType.Topic,
            durable: true
        );
        
        await _rabbit.Channel.ExchangeDeclareAsync(
            exchange: "",
            type: ExchangeType.Topic,
            durable: true
        );
    }
}