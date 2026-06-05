namespace OrderingContext.Application.UseCases.Create.DTOs;

public record CreateOrderResponse(
    int Id,
    IEnumerable<SummaryOrderItemResponse> Items,
    decimal Total);
