namespace OrderingContext.Application.UseCases.Create.DTOs;

public record SummaryOrderItemResponse(
    string Name,
    int Quantity,
    decimal Price,
    decimal Total);
