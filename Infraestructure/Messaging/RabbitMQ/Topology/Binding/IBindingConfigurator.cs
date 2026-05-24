namespace Infraestructure.Messaging.RabbitMQ.Configurations.Binding;

public interface IBindingConfigurator
{
    Task ConfigureAsync();
}