using CatalogContext.Application.DTOs;
using CatalogContext.Application.UseCases;

namespace CatalogContext.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProduct(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/v1/products");

        group.MapGet("/{id:guid}", GetByIdAsync);
        group.MapGet("/", GetAllAsync);
        group.MapPost("/", CreateAsync);
    }

    private static async Task<IResult> GetByIdAsync(
        Guid id,
        GetProductUseCase useCase,
        CancellationToken cancellationToken)
    {
        var product = await useCase.GetByIdAsync(id, cancellationToken);

        return product is null
        ? Results.NotFound($"Product with id {id} not found")
        : Results.Ok(product);
    }
    
    private static async Task<IResult> GetAllAsync(
        GetProductUseCase useCase)
    {
        var products = await useCase.GetAllAsync();
        return Results.Ok(products);
    }
    
    private static async Task<IResult> CreateAsync(
        CreateProductRequest request,
        CreateProductUseCase useCase,
        CancellationToken cancellationToken)
    {
        var response = await useCase.ExecuteAsync(request, cancellationToken);
        
        return Results.Created("/api/v1/products/{id:guid}", response);
    }
}
