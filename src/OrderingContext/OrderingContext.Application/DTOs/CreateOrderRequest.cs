namespace OrderingContext.Application.DTOs;

public record CreateOrderItemInput(
    Guid ProductId,
    string Name,
    decimal Price,
    int Quantity);

public record CreateOrderRequest(
    Guid CustomerId,
    IEnumerable<CreateOrderItemInput> OrderItems);