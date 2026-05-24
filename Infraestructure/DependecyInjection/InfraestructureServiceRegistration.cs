using Application.Abstractions.Persistence;
using Application.Abstractions.Vectorization;
using Infraestructure.Configuration.Options;
using Infraestructure.Messaging.RabbitMQ.Configurations;
using Infraestructure.Messaging.RabbitMQ.Configurations.Binding;
using Infraestructure.Messaging.RabbitMQ.Connection;
using Infraestructure.Messaging.RabbitMQ.Extensions;
using Infraestructure.Messaging.RabbitMQ.HostedServices;
using Infraestructure.Persistence.Context;
using Infraestructure.Persistence.Extensions;
using Infraestructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.DependecyInjection;

public static class InfraestructureServiceRegistration
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRabbitMq(configuration);
        services.AddDatabase(configuration);
       
        return services;
    }
}