namespace OrderingContext.Application.UseCases.Create.DTOs;

public record CreateOrderItemRequest(
    Guid ProductId,
    string Name,
    decimal Price,
    int Quantity);
