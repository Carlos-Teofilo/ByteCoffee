namespace OrderingContext.Application.DTOs;

public record OrderCreatedEvent(
    int OrderId,
    Guid CustomerId,
    decimal TotalAmount);
