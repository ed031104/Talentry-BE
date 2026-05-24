using Infraestructure.Messaging.RabbitMQ.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Infraestructure.Messaging.RabbitMQ.HostedServices;

public class RabbitMqStartupService : IHostedService
{
    private readonly IRabbitMqInitializer _initializer;
    
    public RabbitMqStartupService(IRabbitMqInitializer initializer)
    {
        _initializer = initializer;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken) => await _initializer.InicializeAsync();
    
    public Task StopAsync(CancellationToken cancellationToken)  => Task.CompletedTask;
}