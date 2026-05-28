using CatalogContext.Domain.Repositories;
using CatalogContext.Infrastructure.Data;
using CatalogContext.Infrastructure.Messaging.Consumers;
using CatalogContext.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogContext.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, string connectionString, string rabbitMqConnectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<OrderCreatedConsumer>();
            
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(rabbitMqConnectionString));
                cfg.ReceiveEndpoint("catalog-order-created", e =>
                {
                    e.ConfigureConsumer<OrderCreatedConsumer>(context);
                });
            });
        });
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}