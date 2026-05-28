using OrderingContext.Application.DTOs;
using OrderingContext.Application.UseCases;

namespace OrderingContext.Api.Endpoints;

public static class OrderEndpoints
{
    public static void MapOrder(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/v1/orders");

        group.MapPost("/", CreateAsync);
        group.MapGet("/{id:guid}", GetAllAsync);
    }

    private static async Task<IResult> CreateAsync(
        CreateOrderRequest request,
        CreateOrderUseCase useCase,
        CancellationToken cancellationToken)
    {
        var order = await useCase.ExecuteAsync(request, cancellationToken);
        return Results.Created("/api/v1/orders", order);
    }

    private static async Task<IResult> GetAllAsync(
        Guid id,
        GetOrderUseCase useCase,
        CancellationToken cancellationToken)
    {
        var orders = await useCase.GetAllAsync(id, cancellationToken);
        
        return Results.Ok(orders);
    }
}
