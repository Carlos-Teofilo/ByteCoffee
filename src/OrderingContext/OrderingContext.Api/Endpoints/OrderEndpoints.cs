using MediatR;
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
        OrderingContext.Application.UseCases.Create.Request request,
        ISender mediator,
        CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        
        if (!response.IsSuccess)
            return Results.Json(response, statusCode: response.StatusCode);
        
        return Results.Created($"/api/v1/orders/{response.Order?.Id}", response);
    }

    private static async Task<IResult> GetAllAsync(
        [AsParameters] Guid id,
        GetOrderUseCase useCase,
        CancellationToken cancellationToken)
    {
        var orders = await useCase.GetAllAsync(id, cancellationToken);
        
        return Results.Ok(orders);
    }
}
