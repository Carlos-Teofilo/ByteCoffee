namespace OrderingContext.Application.DTOs;

public record OrderItemResponse(
    string Name,
    decimal Price,
    int Quantity,
    decimal Total
    );