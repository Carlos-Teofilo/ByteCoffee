namespace OrderingContext.Application.UseCases.GetAll.DTOs;

public record SummaryOrderResponse(
    int Id,
    IEnumerable<SummaryOrderItemResponse> Items,
    decimal Total);
