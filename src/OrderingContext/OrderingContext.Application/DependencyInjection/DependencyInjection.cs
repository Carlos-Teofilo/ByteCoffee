using Microsoft.Extensions.DependencyInjection;
using OrderingContext.Application.UseCases;

namespace OrderingContext.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<CreateOrderUseCase>();
        services.AddTransient<GetOrderUseCase>();
        return services;
    }
}