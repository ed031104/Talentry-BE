using Application.Abstractions.Persistence;
using Application.Abstractions.Vectorization;
using Infraestructure.Configuration.Options;
using Infraestructure.Messaging.RabbitMQ.Configurations;
using Infraestructure.Messaging.RabbitMQ.Configurations.Binding;
using Infraestructure.Messaging.RabbitMQ.Connection;
using Infraestructure.Messaging.RabbitMQ.HostedServices;
using Infraestructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Messaging.RabbitMQ.Extensions;

public static class RabbitMqServiceCollectionExtensions
{
    public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqOptions>(
            configuration.GetSection(
                RabbitMqOptions.SectionName)
        );
        
        // Add repositories and unit of work
        services.AddScoped<IUnitofwork, UnitOfWork>();
        services.AddScoped<IEmbeddingRepository, EmbeddingRepository>();
        services.AddScoped<IMatchAnalysisRepository, MatchAnalysisRepository>();
        services.AddScoped<IOutboxRepository, OutboxRepository>();
        services.AddScoped<IResumeAnalysisRepository, ResumeAnalysisRepository>();
        services.AddScoped<IResumeRepository, ResumeRepository>();
        services.AddScoped<IVacancyRepository, VacancyRepository>();
        
        // Add services and configuration rabbitMQ
        services.AddSingleton<IRabbitMqConnection, RabbitMqConnection>();
        services.AddScoped<IExchangeConfiguration, ExchangeConfiguration>();
        services.AddScoped<IQueueConfigurator, QueueConfiguration>();
        services.AddScoped<IBindingConfigurator, BindingConfigurator>();
        services.AddScoped<IRabbitMqInitializer, RabbitMqInitializer>();
        
        
        // Add IHostedService to initialize RabbitMQ configurations at startup
        services.AddHostedService<RabbitMqStartupService>();
        return services;
    }
}