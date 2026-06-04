using MediatR;

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
        [AsParameters] CatalogContext.Application.UseCases.GetById.Request request, // 🟢 Adicionado [AsParameters]
        ISender mediator,
        CancellationToken cancellationToken)
    {
        var product = await mediator.Send(request, cancellationToken);
    
        if (product.Data is null)
            return Results.Json(product.Message, statusCode: product.StatusCode);
        
        return Results.Ok(product);
    }
    
    private static async Task<IResult> GetAllAsync(
        [AsParameters] CatalogContext.Application.UseCases.GetAll.Request request,
        ISender mediator,
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        if (!response.IsSuccess)
            return Results.Json(response, statusCode: response.StatusCode);

        return Results.Ok(response);
    }
    
    private static async Task<IResult> CreateAsync(
        CatalogContext.Application.UseCases.Create.Request request,
        ISender mediator,
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        
        if (!response.IsSuccess)
            return Results.Json(response, statusCode: response.StatusCode);

        return Results.Created($"/api/v1/products/{response.Data.Id}", response);
    }
}