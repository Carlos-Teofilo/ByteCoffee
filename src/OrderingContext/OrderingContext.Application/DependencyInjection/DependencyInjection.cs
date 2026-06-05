using Microsoft.Extensions.DependencyInjection;
using OrderingContext.Application.UseCases;

namespace OrderingContext.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        
        services.AddTransient<GetOrderUseCase>();

        return services;
    }
}