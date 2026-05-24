using Infraestructure.Configuration.Options;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Infraestructure.Messaging.RabbitMQ.Connection;

public sealed class RabbitMqConnection : IRabbitMqConnection
{
    public IChannel Channel { get; }

    public RabbitMqConnection(IOptions<RabbitMqOptions> options)
    {
        var rabbitMqOptions = options.Value;
        var factory = new ConnectionFactory()
        {
            HostName = rabbitMqOptions.Host ?? "localhost",
            UserName = rabbitMqOptions.Username ?? "guest",
            Password = rabbitMqOptions.Password ?? "guest",
            Port = rabbitMqOptions.Port,
            VirtualHost = rabbitMqOptions.VirtualHost ?? "/",
        };

        var connection = factory.CreateConnectionAsync()
            .GetAwaiter()
            .GetResult();
        
        Channel = connection.CreateChannelAsync()
            .GetAwaiter()
            .GetResult();
    }
}