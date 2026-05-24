using Infraestructure.Messaging.RabbitMQ.Connection;

namespace Infraestructure.Messaging.RabbitMQ.Configurations.Binding;

public class BindingConfigurator : IBindingConfigurator
{
    private readonly IRabbitMqConnection _rabbit;
    
    public BindingConfigurator(IRabbitMqConnection rabbit)
    {
        _rabbit = rabbit;
    }
    
    public async Task ConfigureAsync()
    {
        await _rabbit.Channel.QueueBindAsync(
            queue: "",
            exchange: "",
            routingKey: ""
        );
        
        await _rabbit.Channel.QueueBindAsync(
            queue: "",
            exchange: "",
            routingKey: ""
        );
    }
}