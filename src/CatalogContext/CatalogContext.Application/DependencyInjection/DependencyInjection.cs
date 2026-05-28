using CatalogContext.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogContext.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<CreateProductUseCase>();
        services.AddTransient<GetProductUseCase>();
        
        return services;
    }
}