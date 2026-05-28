using OrderingContext.Domain.Entities;

namespace OrderingContext.Application.DTOs;

public record SummaryOrderResponse(
    int Id,
    Guid CustomerId,
    IEnumerable<OrderItemResponse> OrderItems);
