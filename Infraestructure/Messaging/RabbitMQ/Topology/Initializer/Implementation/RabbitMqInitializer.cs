using Infraestructure.Messaging.RabbitMQ.Configurations.Binding;

namespace Infraestructure.Messaging.RabbitMQ.Configurations;

public class RabbitMqInitializer : IRabbitMqInitializer
{
    private readonly IEnumerable<IExchangeConfiguration> _exchangeConfigurators;
    private readonly IEnumerable<IQueueConfigurator> _queueConfigurators;
    private readonly IEnumerable<IBindingConfigurator> _bindingConfigurators;

    public RabbitMqInitializer(IEnumerable<IExchangeConfiguration> exchangeConfigurators,
        IEnumerable<IQueueConfigurator> queueConfigurators, IEnumerable<IBindingConfigurator> bindingConfigurators)
    {
        _exchangeConfigurators = exchangeConfigurators;
        _queueConfigurators = queueConfigurators;
        _bindingConfigurators = bindingConfigurators;
    }

    public async Task InicializeAsync()
    {
        foreach (var exchangeConfigurator in _exchangeConfigurators)
        {
            await exchangeConfigurator.ConfigureAsync();
        }

        foreach (var queueConfiguration in _queueConfigurators)
        {
            await queueConfiguration.ConfigureAsync();
        }

        foreach (var bindingConfigurator in _bindingConfigurators)
        {
            await bindingConfigurator.ConfigureAsync();
        }
    }
}