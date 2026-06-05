using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderingContext.Application.Interfaces;
using OrderingContext.Infrastructure.Data;
using OrderingContext.Infrastructure.Messaging;

namespace OrderingContext.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, string connectionString, string rabbitMqConnectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<
            OrderingContext.Application.UseCases.Create.Contracts.IRepository,
            OrderingContext.Infrastructure.UseCases.Create.Repository>();
        
        services.AddScoped<
            OrderingContext.Application.UseCases.GetAll.Contracts.IRepository,
            OrderingContext.Infrastructure.UseCases.GetAll.Repository>();

        services.AddMassTransit(busConfiguration =>
        {
            busConfiguration.SetKebabCaseEndpointNameFormatter();
            
            busConfiguration.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(rabbitMqConnectionString));
                cfg.ConfigureEndpoints(context);
            });
        });

        services.AddScoped<IEventBus, MassTransitEventBus>();
        
        return services;
    }
}